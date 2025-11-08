// (c) 2020 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SharpCoding.SharpHelpers
{
    public static class DataTableHelper
    {
        /// <summary>
        /// This method set the columns order by name
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public static DataTable SetColumnsOrder(this DataTable table, string[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                if (table.Columns.Contains(columnName))
                {
                    table.Columns[columnName].SetOrdinal(columnIndex);
                    columnIndex++;
                }
            }
            return table;
        }

        /// <summary>
        /// This method return a list of objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            var list = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                var objClass = new T();
                var type = objClass.GetType();
                foreach (DataColumn column in row.Table.Columns)
                {
                    var prop = type.GetProperty(column.ColumnName);
                    if (prop != null)
                        prop.SetValue(objClass, row[column.ColumnName], null);
                }
                list.Add(objClass);
            }
            return list;
        }

        /// <summary>
        /// Converts the DataTable to a CSV format string.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string ToCsv(this DataTable table, string delimiter = ",")
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            string Escape(string s)
            {
                if (s == null) return "";
                bool needQuotes = s.Contains(delimiter) || s.Contains('"') || s.Contains('\n') || s.Contains('\r');
                if (s.Contains('"')) s = s.Replace("\"", "\"\"");
                return needQuotes ? $"\"{s}\"" : s;
            }

            var lines = new List<string>(table.Rows.Count + 1)
            {
                string.Join(delimiter, table.Columns.Cast<DataColumn>().Select(c => Escape(c.ColumnName)))
            };
            foreach (DataRow row in table.Rows)
                lines.Add(string.Join(delimiter, row.ItemArray.Select(v => Escape(v?.ToString()))));
            return string.Join(Environment.NewLine, lines);
        }

        /// <summary>
        /// Adds a new column to the DataTable with the specified default value.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnName"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddColumn<T>(this DataTable table, string columnName, T defaultValue = default!)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            if (string.IsNullOrWhiteSpace(columnName)) throw new ArgumentException("Empty", nameof(columnName));
            if (table.Columns.Contains(columnName)) 
                return;

            var t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            var col = new DataColumn(columnName, t) 
            { 
                DefaultValue = defaultValue! 
            };
            table.Columns.Add(col);
            foreach (DataRow row in table.Rows)
            {
                row[columnName] = defaultValue!;
            }
        }

        /// <summary>
        /// Merges multiple DataTables with the same schema into one.
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DataTable MergeTables(IEnumerable<DataTable> tables)
        {
            if (tables == null) throw new ArgumentNullException(nameof(tables));
            var list = tables.Where(t => t != null).ToList();
            if (list.Count == 0) throw new ArgumentException("No tables.");

            var result = list[0].Clone();
            foreach (var t in list)
            {
                if (!AreSchemasCompatible(result, t))
                    throw new ArgumentException("Tables have incompatible schemas.");
                foreach (DataRow r in t.Rows)
                {
                    result.ImportRow(r);
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether two <see cref="DataTable"/> instances have compatible schemas
        /// for position-based operations (e.g., cloning and row import).
        /// </summary>
        /// <param name="table1">
        /// The first table whose schema is used as the reference (column order matters).
        /// </param>
        /// <param name="table2">
        /// The second table to compare against <paramref name="table1"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if both tables have the same number of columns and, at each position,
        /// the column name matches (case-insensitive) and the <see cref="Type"/> matches;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This check is strictly positional: it does not attempt to realign columns by name.
        /// Extended properties, nullability metadata, constraints, and keys are not compared.
        /// </remarks>
        private static bool AreSchemasCompatible(DataTable a, DataTable b)
        {
            if (a.Columns.Count != b.Columns.Count) return false;
            for (int i = 0; i < a.Columns.Count; i++)
            {
                var ca = a.Columns[i]; var cb = b.Columns[i];
                if (!ca.ColumnName.Equals(cb.ColumnName, StringComparison.OrdinalIgnoreCase)) return false;
                if (ca.DataType != cb.DataType) return false;
            }
            return true;
        }

        /// <summary>
        /// Filters the rows in the DataTable based on a predicate.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static DataTable Filter(this DataTable table, Func<DataRow, bool> predicate)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var filteredTable = table.Clone();
            foreach (DataRow row in table.AsEnumerable().Where(predicate))
            {
                filteredTable.ImportRow(row);
            }
            return filteredTable;
        }

        /// <summary>
        /// Checks if the DataTable is empty (contains no rows).
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DataTable table)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));

            return table.Rows.Count == 0;
        }

        /// <summary>
        /// Removes duplicate rows based on specified columns.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public static DataTable RemoveDuplicates(this DataTable table, params string[] columnNames)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));

            var distinctTable = table.Clone();
            var uniqueRows = new HashSet<string>();

            foreach (DataRow row in table.Rows)
            {
                var key = string.Join("|", columnNames.Select(c => row[c]?.ToString() ?? ""));
                if (uniqueRows.Add(key))
                {
                    distinctTable.ImportRow(row);
                }
            }
            return distinctTable;
        }
    }
}
