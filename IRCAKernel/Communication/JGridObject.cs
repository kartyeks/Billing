using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace IRCA.Communication
{
    /// <summary>
    /// The sorting type on the grid.
    /// </summary>
    public enum SortType
    {
        INT, FLOAT, DATE, STRING
    }

    /// <summary>
    /// Sorting order of the grid column
    /// </summary>
    public enum SortOrder
    {
        DESC, ASC
    }

    /// <summary>
    /// The jquery row object. Which has the ID of the row and cell value
    /// </summary>
    public class RowObject
    {
        public String id;
        public String[] cell;
    }

    /// <summary>
    /// Column model defines each column. 
    /// </summary>
    public class ColumnModel
    {
        public String name;
        public String index;
        public String width;
        public String sorttype;
        public bool sortable;
        public bool frozen;
        public bool editable;
        public bool hidden;
        public object formatter;
       
    }

    /// <summary>
    /// The object which stores all the rows for the grid
    /// </summary>
    public class Row
    {
        public RowObject[] rows;
    }

    public class GroupHeaders
    {
        public String startColumnName;
        public int numberOfColumns;
        public String titleText;
    }

    public class SpanGroupHeaders
    {
        public bool useColSpanStyle;
        public GroupHeaders[] groupHeaders;
    }

    /// <summary>
    /// The object which will be passed to JQuery grid to construct the grid object
    /// </summary>
    public class JGridObject
    {
        public String datatype;
        public Row datastr;
        public int height;
        public int width;
        public String[] colNames;
        public ColumnModel[] colModel;
        public String pager;
        public int rowNum;
        public int[] rowList;
        public String sortname;
        public String sortorder;
        public bool viewrecords;
        public bool gridview;
        public bool multiselect;
        public String caption;
        public String loadComplete;
        public Object[] toolbar;
        public bool rownumbers;
        public int page;
        public bool ignoreCase;
        public bool subGrid;
        public Object[] subGridOptions;
        public String subGridRowExpanded;
        public bool shrinkToFit;
    }

    /// <summary>
    /// The class which will build the JQuery grid object. 
    /// Object will take all the data, construct the final data
    /// </summary>
    public class JGridObjectBuilder
    {
        private List<JGridDataObject> _ListRows;
        private String _IDColumnName;


        private SortOrder _SortOrder;
        private int _Height;
        private int _Width;
        private int[] _RowNumber;
        private int _RowsPerPage;
        private String _SortName;
        private bool _ViewRecords;
        private bool _GridView;
        private bool _MultiSelect;
        private String _Caption;
        private Object[] _Toolbar;
        private bool _RowNumbers;
        private int _Page;
        private bool _IgnoreCase;
        private bool _shrinkToFit;


        private JGridObject _GridData;
        List<MemberInfo> _DataFieldList = new List<MemberInfo>();
        List<ColumnModel> _ListColModel = new List<ColumnModel>();

        public SortOrder SortingOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }

        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public int RowsPerPage
        {
            get { return _RowsPerPage; }
            set { _RowsPerPage = value; }
        }

        public int[] RowCountList
        {
            get { return _RowNumber; }
            set { _RowNumber = value; }
        }

        public String SortName
        {
            get { return _SortName; }
            set { _SortName = value; }
        }

        public bool ViewRecords
        {
            get { return _ViewRecords; }
            set { _ViewRecords = value; }
        }

        public bool GridView
        {
            get { return _GridView; }
            set { _GridView = value; }
        }

        public bool MultiSelect
        {
            get { return _MultiSelect; }
            set { _MultiSelect = value; }
        }

        public String Caption
        {
            get { return _Caption; }
            set { _Caption = value; }
        }

        public Object[] Toolbar
        {
            get { return _Toolbar; }
            set { _Toolbar = value; }
        }

        public bool RowNumbers
        {
            get { return _RowNumbers; }
            set { _RowNumbers = value; }
        }

        public int Page
        {
            get { return _Page; }
            set { _Page = value; }
        }

        public bool IgnoreCase
        {
            get { return _IgnoreCase; }
            set { _IgnoreCase = value; }
        }
        public bool shrinkToFit
        {
            get { return _shrinkToFit; }
            set { _shrinkToFit = value; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IDColumnName">The field name which will be used as row ID</param>
        /// <param name="ValueObjecType">Type of the object which will be displayed on the row</param>
        public JGridObjectBuilder(String IDColumnName, Type ValueObjecType)
        {
            _ListRows = new List<JGridDataObject>();
            _GridData = new JGridObject();
            _DataFieldList = new List<MemberInfo>();

            _GridData.colModel = new ColumnModel[_DataFieldList.Count];

            _IDColumnName = IDColumnName;

            // Get all the public fields and properties.
            _DataFieldList.AddRange(ValueObjecType.GetFields(BindingFlags.Public | BindingFlags.Instance));
            _DataFieldList.AddRange(ValueObjecType.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            _Caption = ValueObjecType.Name;

            // Create the grid header based on the field names. The fields names will be split based on the 
            // Capital letter and column header will be created.
            _GridData.colNames = new String[_DataFieldList.Count];
            for (int i = 0; i < _DataFieldList.Count; i++)
            {
                _GridData.colNames[i] = Regex.Replace(_DataFieldList[i].Name, "[A-Z]", delegate(Match match)
                {
                    return ' ' + match.ToString();
                });
            }

            // Default values 
            _Height = 280;
            _Width = 900;
            _RowNumber = new int[] { 10, 20, 30, 40 };
            _RowsPerPage = 10;
            _SortName = IDColumnName;
            _SortOrder = SortOrder.ASC;
            _ViewRecords = true;
            _GridView = true;
            _GridData.loadComplete = "fireOnLoad()";
            _Toolbar = new object[] { true, "top" };
            _RowNumbers = true;
            _Page = 1;
            _IgnoreCase = true;

            _GridData.datatype = "jsonstring";
            _GridData.caption = _Caption;
            _GridData.height = _Height;
            _GridData.width = _Width;
            _GridData.pager = "#pager";
            _GridData.rowNum = _RowsPerPage;
            _GridData.rowList = _RowNumber;
            _GridData.sortname = _SortName;
            _GridData.sortorder = _SortOrder.ToString();
            _GridData.viewrecords = true;
            _GridData.gridview = true;
            _GridData.multiselect = false;
            _GridData.caption = _Caption;
            _GridData.toolbar = _Toolbar;
            _GridData.rownumbers = _RowNumbers;
            _GridData.page = _Page;
            _GridData.ignoreCase = _IgnoreCase;
            _GridData.shrinkToFit = true;
        }

        /// <summary>
        /// Add single row data to the builder.
        /// </summary>
        /// <param name="RowData">The object which will be displayed on screen</param>
        public void AddRow(JGridDataObject RowData)
        {
            _ListRows.Add(RowData);
        }

        /// <summary>
        /// Add multiple rows to the builder
        /// </summary>
        /// <param name="RowData"></param>
        public void AddRow(JGridDataObject[] RowData)
        {
            _ListRows.AddRange(RowData);
        }

        /// <summary>
        /// Set the column model. 
        /// </summary>
        /// <param name="ColumnName">Name of the column</param>
        /// <param name="Width">Width on the screen</param>
        /// <param name="IsSortable">Can user do sort on the field</param>
        /// <param name="SortType">Sorty type</param>
        public void AddColumnModel(String ColumnName, int Width, bool IsSortable, SortType SortType)
        {
            _ListColModel.Add(new ColumnModel()
            {
                name = ColumnName
                ,
                sortable = false
                ,
                width = Convert.ToString(Width)
                ,
                index = ColumnName
                ,
                sorttype = SortType.ToString().ToLower()
            });
        }

        /// <summary>
        /// This method construct the final JQuery Grid object.
        /// </summary>
        /// <returns></returns>
        public JGridObject GetGridObject()
        {
            if (_ListRows.Count <= 0)
            {
                return _GridData;
            }

            _GridData.datastr = new Row();
            _GridData.datastr.rows = new RowObject[_ListRows.Count];

            //Take each row data and do process
            for (int i = 0; i < _ListRows.Count; i++)
            {
                _GridData.datastr.rows[i] = new RowObject();

                _GridData.datastr.rows[i].cell = new String[_DataFieldList.Count];

                Object Data = _ListRows[i].GetGridData();

                for (int j = 0; j < _DataFieldList.Count; j++)
                {
                    Object ValueObject;

                    // Based on the filed type the value will be retrived.
                    if (_DataFieldList[j] is FieldInfo)
                    {
                        ValueObject = ((FieldInfo)_DataFieldList[j]).GetValue(Data);
                    }
                    else
                    {
                        if (((PropertyInfo)_DataFieldList[j]).CanRead)
                        {
                            ValueObject = ((PropertyInfo)_DataFieldList[j]).GetValue(Data, null);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    String Value;

                    //The date time valuw should be in proper order.
                    if (ValueObject is DateTime)
                    {
                        Value = ((DateTime)ValueObject).ToString("yyyy-MM-dd hh:mm:ss.sss");
                    }
                    else
                    {
                        if (ValueObject != null)
                            Value = ValueObject.ToString();
                        else
                            Value = String.Empty; ;
                    }

                    _GridData.datastr.rows[i].cell[j] = Value;

                    if (_IDColumnName == _DataFieldList[j].Name)
                    {
                        _GridData.datastr.rows[i].id = Value;
                    }
                }
            }

            //Update column model
            for (int i = 0; i < _ListColModel.Count; i++)
            {
                _GridData.colModel[i] = _ListColModel[i];
            }


            return _GridData;
        }
    }

    /// <summary>
    /// The inteface which should be implemented by class which is going to be added in the grid
    /// </summary>
    public interface JGridDataObject
    {
        Object GetGridData();
    }
}
