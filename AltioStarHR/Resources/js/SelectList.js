  ?/// <reference name="MicrosoftAjax.js"/>
   /// <reference path="ListItems.js"/>
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
 
