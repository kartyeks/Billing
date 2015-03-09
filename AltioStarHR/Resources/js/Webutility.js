function toDouble(Value) {
        if (Value == null || Value.length <= 0 || isNaN(Value)) {
            return 0;
        }
        else {
            return parseFloat(Value);
        }
    }

    function toInt(Value) {
        if (Value == null || Value.length <= 0 || isNaN(Value)) {
            return 0;
        }
        else {
            return parseInt(Value);
        }
    }

    function init() {
        jQuery.support.cors = true;
    }

    function htmlEncode(value) {
        if (typeof (value) == 'undefined') {
            return '';
        }

        return $('<div/>').text(value).html();
    }

    function FromJson(JsonString) {
        return JSON.parse(JsonString);
    }

    function ToJson(JsonObject) {
        return JSON.stringify(JsonObject);
    }

    function SendApplicationRequest(Command, Data, DisableAutoErrorHandling, RequestHandler, PagePath) { 
        
        init();
        var RequestData = typeof Data == 'string' ? Data : ToJson(Data);

        var Response = new Object();
        Response.ResponseCommand = 'ERROR';
        Response.Message = 'Error in sending Web Request!';

        var RequestPage = null;

        if (!PagePath) {
            RequestPage = "~/AppCommandHandler.ashx";
        }        
        else {
            RequestPage = PagePath;
        }

        $.ajax
        (
            {
                type: 'POST',
                url: RequestPage,
                data: 'RequestCommand=' + escape(Command) + '&RequestData=' + escape(RequestData) + '&RequestHandler=' + escape(RequestHandler),
                processData: false,
                async: false,
                success:
                    function(ResponseData) {
                        Response = ResponseData;
                    },
                error:
                    function(XMLHttpRequest, textStatus, errorThrown) {
                        Response.Message = 'Error in Web Request Response!';
                        Response.MessageDetail = textStatus + '-' + (errorThrown ? errorThrown : '');
                    }
            }
        );

        if (Response.ResponseCommand == 'ERROR' && PagePath != null) {

            var ret = window.showModalDialog('default.aspx?serve=DownloadFile&Message=' +
             'BROWSER_LOCAL_SERVICE_ERROR' +
              '&FileName=~/bin/LocalService.exe', window.self,
               "dialogHeight:100px; dialogWidth:300px; resizable:no; status:no; scroll:no;");

        }

        return Response;
    }
    function LoadPermissions(modulename, employeeid) {
    
        var arr = '';
        var Response = new Object();
        var Request = new Object();
        Request.FunctionName = modulename;
        Request.EmployeeID = employeeid;
        Response = SendApplicationRequest("GET_PERMISSION_ASSIGNED", Request, true);
        if (Response.ResponseCommand == "SUCCESS") {
            arr = Response.ResponseObject;
        }
        return arr;
    }
    
    (function() {
    window.generic = {
        list: function() {
            return {
                hasValue: function(obj) {
                    return (((typeof (obj) == 'undefined') || (obj == null)) == false);
                },
                items: [],
                item: function(index, obj) {
                    if (this.hasValue(obj))
                        this.items[index] = obj;
                    else
                        return this.items[index];
                },
                property: function(index, pro, value) {
                    if (this.hasValue(value))
                        this.items[index][pro] = value;
                    else
                        return this.items[index][pro];
                },
                extend: function(index, obj) {
                    var key;
                    for (key in obj) {
                        this.property(index, key, obj[key]);
                    }
                },
                add: function(obj) {
                    this.items[this.items.length] = obj;
                },
                addRange: function(objArray) {
                    var i = 0;
                    for (i = 0; i < objArray.length; i++) {
                        this.items[this.items.length] = objArray[i];
                    };
                },
                insert: function(obj, index) {
                    if (this.items.length > 0) {
                        var i = 0;
                        for (i = this.items.length; i > index; i--) {
                            this.items[i] = this.items[(i - 1)];
                        };
                        this.items[index] = obj;
                    } else {
                        this.items[0] = obj;
                    };
                },
                isEqual: function(a, b) {
                    return (a === b);
                },
                find: function(obj) {
                    var result = -1;
                    var i = 0;
                    for (i = 0; i < this.items.length; i++) {
                        if (this.isEqual(this.items[i], obj)) {
                            result = i;
                            break;
                        };
                    };
                    return result;
                },
                clear: function() {
                    this.items = [];
                },
                remove: function(obj) {
                    var tmp = [], i = 0, j = 0;
                    for (i = 0; i < this.items.length; i++) {
                        if (!this.isEqual(this.items[i], obj)) {
                            tmp[j++] = this.items[i];
                        };
                    };
                    this.clear();
                    this.items = tmp;
                },
                removeAt: function(index) {
                    this.remove(this.items[index]);
                },
                join: function(seprator, pro) {
                    var i = 0;
                    var result = "";
                    var count = this.items.length;
                    for (i = 0; i < count; i++) {
                        if (i == (count - 1)) {
                            result += (this.hasValue(pro)) ? this.items[i][pro] : this.items[i];
                        } else {
                            result += (this.hasValue(pro)) ? this.items[i][pro] : this.items[i];
                            result += seprator;
                        };
                    };
                    return result;
                }
            };
        }
    };
})();


   var selectlist = function(ID, autoLoad) {
       this.id = ID;
       this.options = new generic.list();
       this.values = "value";
       this.display = "text";
      this.options.base = this;
       this.options.isEqual = function(a, b) {
           return ((a[this.base.values] == b[this.base.values]) && (a[this.base.display] == b[this.base.display]));
      };
      if (autoLoad)
           this.load();
  };
   selectlist.prototype.getOptions = function() {
      return this.options;
   };
  selectlist.prototype.setOptions = function(genericList) {
      this.optinos = genericList;
  };
  selectlist.prototype.find = function(text, value) {
      var obj = this.newObject(text, value);
     return this.findItem(obj);
  };
  selectlist.prototype.findItem = function(item) {
      return this.options.find(item);
  };
  selectlist.prototype.newObject = function(text, value) {
      var p = new Object();
      p[this.values] = value;
     p[this.display] = text;
      return p;
  };
  selectlist.prototype.add = function(text, value, rebuild) {
     var obj = this.newObject(text, value);
      this.addItem(obj, rebuild);
  };
  selectlist.prototype.addItem = function(item, rebuild) {
      this.options.add(item);
      if (rebuild)
          this.build();
  };
 selectlist.prototype.insert = function(text, value, index, rebuild) {
      var obj = this.newObject(text, value);
      this.insertItem(obj, index, rebuild);
  };
  selectlist.prototype.insertItem = function(item, index, rebuild) {
      this.options.insert(item, index);
      if (rebuild)
          this.build();
  };
  selectlist.prototype.addRange = function(itemsArray, rebuild) {
      this.options.addRange(itemsArray);
      if (rebuild)
          this.build();
  };
  selectlist.prototype.remove = function(text, value) {
      var obj = this.newObject(text, value);
      this.removeItem(obj);
};
  selectlist.prototype.removeItem = function(item) {
      this.options.remove(item);
      this.build();
  };
  selectlist.prototype.removeAt = function(index) {
      this.options.removeAt(index);
      this.build();
  };
  selectlist.prototype.join = function(seprator, property) {
     var key = (property) ? property : this.values;
      return this.options.join(seprator, key);
  };
  selectlist.prototype.setValue = function(nameString) {
      this.values = nameString;
  };
  selectlist.prototype.setDisplay = function(nameString) {
      this.display = nameString;
  };
  selectlist.prototype.getName = function(index) {
      return this.getPorperty(index, this.display);
  };
  selectlist.prototype.getValue = function(index) {
      return this.getPorperty(index, this.values);
  };
  selectlist.prototype.getPorperty = function(index, property) {
      return this.options.property(index, property);
  };
  selectlist.prototype.getJson = function(datasetName) {
      var result = "";
      result = (datasetName) ? "{" + datasetName + ":[" : "{[";
      var iloop = 0;
      var tmp;
      var lastIndex = this.options.items.length - 1;
      for (iloop = 0; iloop < this.options.items.length; iloop++) {
          result += "{";
          tmp = this.options.items[iloop];
          for (key in tmp) {
              result += key + ":'" + tmp[key] + "',";
          };
          result = result.substring(0, (result.length - 1));
          result += "}";
          if (iloop != lastIndex)
              result += ",";
      };
      result += "]}";
      return result;
  };
  selectlist.prototype.clear = function(deleteOld) {
      var thisBox = document.getElementById(this.id);
     var opLength = thisBox.options.length;
      var i = 0;
      for (i = 0; i < opLength; i++) {
          thisBox.options[0] = null;
      };
      if (deleteOld) {
          this.options.clear();
      };
  };
  selectlist.prototype.build = function() {
     this.clear();
      var thisBox = document.getElementById(this.id);
      var i = 0;
      for (i = 0; i < this.options.items.length; i++) {
          thisBox.options[i] = new Option(this.options.items[i][this.display], this.options.items[i][this.values]);
      };
  };
  selectlist.prototype.load = function() {
      this.options.clear();
      var thisBox = document.getElementById(this.id);
      var i = 0;
      var tmp;
      for (i = 0; i < thisBox.options.length; i++) {
          this.options.add(this.newObject(thisBox.options[i].text, thisBox.options[i].value));
      };
  };
  selectlist.prototype.selectedIndex = function() {
      var result = new generic.list();
      var i = 0;
      var tbox = document.getElementById(this.id);
      for (i = 0; i < tbox.options.length; i++) {
          if (tbox.options[i].selected) {
              result.add(i);
          };
      };
      return result;
  };
  selectlist.prototype.removeSelected = function() {
      var indexlist = this.selectedIndex();
      var i = 0;
      for (i = 0; i < indexlist.items.length; i++) {
          this.options.removeAt(indexlist.items[i] - i);
      };
      this.build();
  };
  selectlist.prototype.setSelectedIndex = function(index) {
      var tbox = document.getElementById(this.id);
      tbox.options[index].selected = true;
  };
  selectlist.prototype.setSelectedValue = function(value) {
     var i;
      for (i = 0; i < this.options.items.length; i++) {
          if (this.options.items[i][this.values] == value) {
              this.selectedIndex(i);
              break;
         };
      };
  };
  selectlist.prototype.setSelectedIndexs = function(indexArray) {
      var tbox = document.getElementById(this.id);
     var i = 0;
      for (i = 0; i < indexArray.length; i++) {
          tbox.options[index].selected = true;
      };
  };
  selectlist.prototype.setSelectedValues = function(valueArray) {
      var indexArray = new generic.list();
      var i, j;
     for (i = 0; i < this.options.items.length; i++) {
          for (j = 0; j < valueArray.length; i++) {
             if (this.options.items[i][this.values] == valueArray[j]) {
                  indexArray.add(i);
              };
          };
      };
      this.setSelectedIndexs(indexArray.getItems());
  };
  selectlist.prototype.addFrom = function(sourceID, remove) {
      this.load();
      var source = new selectlist(sourceID);
      source.load();
      var indexlist = source.selectedIndex();
      var i = 0;
     for (i = 0; i < indexlist.items.length; i++) {
          this.options.insert(this.newObject(source.options.items[indexlist.items[i]].text, source.options.items[indexlist.items[i]].value), 0);
     };
      this.build();
      if (remove) {
          source.removeSelected();
      };
  };
 selectlist.prototype.move = function(upMode) {
      this.load();
      var downMode = (upMode != true);
      var tbox = document.getElementById(this.id);
     var i = 0;
      var indexlist = new generic.list();
      var lastIndex = (tbox.options.length - 1);
      indexlist = this.selectedIndex();
      var iIndex, iIndexAfter, update;
      for (i = 0; i < indexlist.items.length; i++) {
         update = false;
          iIndex = indexlist.items[i];
         if ((upMode == true) && (iIndex > 0)) {
              update = true;
             iIndexAfter = iIndex - 1;
         };
          if ((downMode == true) && (iIndex < lastIndex)) {
              update = true;
              iIndexAfter = iIndex + 1;
          };
          if (update) {
              var tmp = this.options.items[iIndex];
             this.options.removeAt(iIndex);
              indexlist.items[i] = iIndexAfter;
              this.options.insert(tmp, iIndexAfter);
          };
      };
      this.build();
     for (i = 0; i < indexlist.items.length; i++) {
         tbox.options[indexlist.items[i]].selected = true;
      };
  };
 
