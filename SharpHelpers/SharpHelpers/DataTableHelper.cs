// (c) 2020 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
