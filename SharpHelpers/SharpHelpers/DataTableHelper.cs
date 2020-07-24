// (c) 2020 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.Data;

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
    }
}
