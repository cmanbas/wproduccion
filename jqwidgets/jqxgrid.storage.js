/*
jQWidgets v19.0.0 (2024-Feb)
Copyright (c) 2011-2024 jQWidgets.
License: https://jqwidgets.com/license/
*/
/* eslint-disable */

(function(a){a.extend(a.jqx._jqxGrid.prototype,{savestate:function(b){if(this.loadingstate){return}var c=this.getstate();if(b!==undefined&&!a.isEmptyObject(b)){if(b.indexOf("sort")==-1){delete c.sortcolumn;delete c.sortdirection}if(b.indexOf("pager")==-1){delete c.pagenum;delete c.pagesizeoptions;delete c.pagesize}if(b.indexOf("selection")==-1){delete c.selectedcells;delete c.selectedrowindexes;delete c.selectedrowindex}if(b.indexOf("grouping")==-1){delete c.groups}if(b.indexOf("filter")==-1){delete c.filters}a.each(this.columns.records,function(e){var d=c.columns[this.datafield];if(b.indexOf("hidden_columns")==-1){delete d.hidden}if(b.indexOf("reorder")==-1){delete d.index}if(b.indexOf("columns_width")==-1){delete d.width}if(b.indexOf("columns_text")==-1){delete d.text}if(b.indexOf("alignment")==-1){delete d.align;delete d.cellsalign}})}if(window.localStorage){window.localStorage["jqxGrid"+this.element.id]=this._stringify(c)}this._savedstate=c;return c},loadstate:function(j,g){var b="";if(j!=undefined&&j.width!=undefined){b=j}else{if(window.localStorage){var c=window.localStorage["jqxGrid"+this.element.id];if(c){var b=a.parseJSON(window.localStorage["jqxGrid"+this.element.id])}}else{if(this._savedstate){var b=this._savedstate}}}if(b!=null&&b!==""){if(this.virtualmode||(this.source._source.url&&this.source._source.url!="")){this.source.beginUpdate()}var d=b;if(d.width!==undefined){this.width=d.width}if(d.height!==undefined){this.height=d.height}if(this.pageable){if(d.pagesize!=undefined){this.pagesize=d.pagesize;this.dataview.pagesize=d.pagesize}if(d.pagenum!=undefined){this.dataview.pagenum=d.pagenum}if(d.pagesizeoptions!=undefined){this.pagesizeoptions=d.pagesizeoptions}if(this.pagesizeoptions){var f=0;for(var e=0;e<this.pagesizeoptions.length;e++){if(this.pagesize>=this.pagesizeoptions[e]){f=e}}if(this.pagershowrowscombo){this.pagershowrowscombo.jqxDropDownList({selectedIndex:f})}}}if(this.sortable){if(this._loading){this._loading=false}if(d.sortdirection){if(d.sortdirection.ascending||d.sortdirection.descending){this.dataview.sortfield=d.sortcolumn;var h=d.sortdirection.ascending?"asc":"desc";this.dataview.sortfielddirection=h;this.source.sortcolumn=d.sortcolumn;this.source.sortdirection=h;this.sortby(d.sortcolumn,h)}}else{if(this.dataview.sortfield!=null&&(this.dataview.sortfielddirection=="asc"||this.dataview.sortfielddirection=="desc")){this.sortby(this.dataview.sortfield,null)}}if(d.sortcolumns){for(var e=0;e<d.sortcolumns.length;e++){var k=d.sortcolumns[e];this.sortby(k.dataField,k.ascending)}}}if(this.groupable&&d.groups){this.dataview.groups=d.groups;this.groups=d.groups}this.loadingstate=true;if(this.virtualsizeinfo){this._loadselectionandcolumnwidths(d)}this.loadingstate=false;if(this.virtualmode||(this.source._source.url&&this.source._source.url!="")){if(g==true){this.source.endUpdate(false)}else{this.source.endUpdate(false);if(this.virtualmode||this.source._source.filter||this.source._source.sort){this.updatebounddata("state")}}}}},_loadselectionandcolumnwidths:function(j){this.loadingstate=true;var m="";if(j!=undefined&&j.width!=undefined){m=j}else{if(window.localStorage){if(window.localStorage["jqxGrid"+this.element.id]){var m=a.parseJSON(window.localStorage["jqxGrid"+this.element.id])}}else{if(this._savedstate){var m=this._savedstate}}}if(m!=null&&m!=""){var G=this._loading;this._loading=false;var I=m;var H=this;var g=false;var d=[];d.length=0;var E=[];a.each(this.columns.records,function(K){var i=I.columns[this.datafield];if(i!=undefined){if(this.text!=i.text){g=true}if(this.hidden!=i.hidden){g=true}if(i.width!==undefined){this.width=i.width;if(this._width){this._width=null}if(this._percentagewidth){this._percentagewidth=null}}if(i.hidden!==undefined){this.hidden=i.hidden}if(i.pinned!==undefined){this.pinned=i.pinned}if(i.groupable!==undefined){this.groupable=i.groupable}if(i.resizable!==undefined){this.resizable=i.resizable}this.draggable=i.draggable;if(i.text!==undefined){this.text=i.text}if(i.align!==undefined){this.align=i.align}if(i.cellsalign!==undefined){this.cellsalign=i.cellsalign}if(H._columns){for(var J=0;J<H._columns.length;J++){if(H._columns[J].datafield==this.datafield){if(i.hidden!==undefined){H._columns[J]["hidden"]=i.hidden}if(i.width!==undefined){H._columns[J]["width"]=i.width}}}}if(i.index!==undefined){d[this.datafield]=i.index;d.length++}}});if(d.length>0){if(this.setcolumnindex){var y=this.rowdetails?1:0;y+=this.groupable?this.groups.length:0;var v=new Array();for(var D=0;D<this.columns.records.length;D++){v.push(this.columns.records[D])}var C=0;var f=new Array();for(var D=0;D<v.length;D++){var k=v[D];var n=d[k.datafield];if(this.groupable&&k.grouped){C++;continue}if(D==0&&this.rowdetails){C++;continue}if(D!==n||this.groupable||this.rowdetails){var q=C+n;f.push({column:k,key:q})}}f.sort(function(J,i){if(J.key<i.key){return -1}if(J.key>i.key){return 1}return 0});f.reverse();a.each(f,function(i,K){var J=this.key;H.setcolumnindex(this.column.datafield,J,false)})}this.prerenderrequired=true;if(this.groupable){this._refreshdataview()}this.rendergridcontent(true);if(this._updatefilterrowui&&this.filterable&&this.showfilterrow){this._updatefilterrowui()}this._renderrows(this.virtualsizeinfo);if(this.groupable&&I.groups!==undefined){var F=this.source?this.source.datafields:null;if(F==null&&this.source&&this.source._source){F=this.source._source.datafields;var x=this;if(x._columns){x._columns.sort(function(K,J){var N;var M;for(var L=0;L<x.columns.records.length;L++){if(x.columns.records[L].datafield===K.datafield){N=L}if(x.columns.records[L].datafield===J.datafield){M=L}}if(N<M){return -1}if(N>M){return 1}return 0})}}}}if(this.filterable&&I.filters!==undefined){if(this.clearfilters){this._loading=false;this.clearfilters(false)}var c="";var p=new a.jqx.filter();for(var D=0;D<I.filters.filterscount;D++){var B=I.filters["filtercondition"+D];var u=I.filters["filterdatafield"+D];var k=this.getcolumn(u);if(u!=c){p=new a.jqx.filter()}c=u;if(k&&k.filterable){var z=I.filters["filtervalue"+D];var r=I.filters["filteroperator"+D];var b=I.filters["filtertype"+D];if(b=="datefilter"){var s=p.createfilter(b,z,B,null,k.cellsformat,this.gridlocalization)}else{var s=p.createfilter(b,z,B)}p.addfilter(r,s);if(this.showfilterrow){var l=k._filterwidget;var e=k._filterwidget.parent();if(l!=null){switch(k.filtertype){case"number":e.find("input").val(z);if(this.host.jqxDropDownList){var o=p.getoperatorsbyfiltertype("numericfilter");l.find(".filter").jqxDropDownList("selectIndex",o.indexOf(B))}break;case"date":if(this.host.jqxDateTimeInput){a(e.children()[0]).jqxDateTimeInput("setDate",z)}else{l.val(z)}break;case"range":if(this.host.jqxDateTimeInput){var t=I.filters["filtervalue"+(D+1)];var b=I.filters["filtertype"+D];var s=p.createfilter(b,t,"LESS_THAN_OR_EQUAL");p.addfilter(r,s);var A=new Date(z);var h=new Date(t);if(isNaN(A)){A=a.jqx.dataFormat.tryparsedate(z)}if(isNaN(h)){h=a.jqx.dataFormat.tryparsedate(z)}a(e.children()[0]).jqxDateTimeInput("setRange",A,h);D++}else{l.val(z)}break;case"textbox":case"default":l.val(z);H["_oldWriteText"+l[0].id]=z;break;case"list":if(this.host.jqxDropDownList){var w=a(e.children()[0]).jqxDropDownList("getItems");var n=-1;a.each(w,function(J){if(this.value==z){n=J;return false}});a(e.children()[0]).jqxDropDownList("selectIndex",n)}else{l.val(z)}break;case"checkedlist":if(!this.host.jqxDropDownList){l.val(z)}break;case"bool":case"boolean":if(!this.host.jqxCheckBox){l.val(z)}else{a(e.children()[0]).jqxCheckBox({checked:z})}break}}}this.addfilter(u,p)}}if(I.filters&&I.filters.filterscount>0){this.applyfilters();if(this.showfilterrow){a.each(this.columns.records,function(){if(this.filtertype=="checkedlist"&&this.filterable){if(H.host.jqxDropDownList){var N=this;var L=N._filterwidget;var Q=L.jqxDropDownList("getItems");var J=L.jqxDropDownList("listBox");J.checkAll(false);if(N.filter){J.uncheckAll(false);var P=N.filter.getfilters();for(var M=0;M<J.items.length;M++){var K=J.items[M].label;a.each(P,function(){if(this.condition=="NOT_EQUAL"){return true}if(K==this.value){J.checkIndex(M,false,false)}})}J._updateCheckedItems();var O=J.getCheckedItems().length;if(J.items.length!=O&&O>0){J.host.jqxListBox("indeterminateIndex",0,true,false)}}}}})}}if(this.pageable&&I.pagenum!==undefined){if(this.gotopage&&!this.virtualmode){this.dataview.pagenum=-1;this.gotopage(I.pagenum)}else{if(this.gotopage&&this.virtualmode){this.gotopage(I.pagenum)}}}}if(I.selectedrowindexes&&I.selectedrowindexes&&I.selectedrowindexes.length>0){this.selectedrowindexes=I.selectedrowindexes;this.selectedrowindex=I.selectedrowindex;if(this.selectionmode==="checkbox"){this._updatecheckboxselection()}}if(I.selectedcells){if(this._applycellselection){a.each(I.selectedcells,function(){H._applycellselection(this.rowindex,this.datafield,true,false)})}}if(this.groupable&&I.groups!==undefined){this._refreshdataview();this.render();this._loading=G;this.loadingstate=false;return}if(g){this.prerenderrequired=true;this.rendergridcontent(true);this._loading=G;this.loadingstate=false;if(this.updating()){return false}}else{this._loading=G;this._updatecolumnwidths();this._updatecellwidths();this.loadingstate=false}this.loadingstate=false;this._loading=G;this._renderrows(this.virtualsizeinfo)}this.loadingstate=false},getstate:function(){var p=this.getdatainformation();var h={};h.width=this.width;h.height=this.height;h.pagenum=p.paginginformation.pagenum;h.pagesize=p.paginginformation.pagesize;h.pagesizeoptions=this.pagesizeoptions;h.sortcolumn=p.sortinformation.sortcolumn;h.sortdirection=p.sortinformation.sortdirection;if(this.sortmode==="many"){h.sortcolumns=this.getsortcolumns()}if(this.selectionmode!=null){if(this.getselectedcells){if(this.selectionmode.toString().indexOf("cell")!=-1){var o=this.getselectedcells();var q=new Array();a.each(o,function(){q.push({datafield:this.datafield,rowindex:this.rowindex})});h.selectedcells=q}else{var n=this.getselectedrowindexes();h.selectedrowindexes=n;h.selectedrowindex=this.selectedrowindex}}}var i={};var d=0;if(this.dataview.filters){for(var j=0;j<this.dataview.filters.length;j++){var e=this.dataview.filters[j].datafield;var b=this.dataview.filters[j].filter;var c=b.getfilters();i[e+"operator"]=b.operator;for(var f=0;f<c.length;f++){c[f].datafield=e;if(c[f].type=="datefilter"){if(c[f].value&&c[f].value.toLocaleString){var g=this.getcolumn(c[f].datafield);if(g.cellsformat){var l=this.source.formatDate(c[f].value,g.cellsformat,this.gridlocalization);if(l){i["filtervalue"+d]=l}else{i["filtervalue"+d]=c[f].value.toLocaleString()}}else{i["filtervalue"+d]=c[f].value.toLocaleString()}}else{i["filtervalue"+d]=c[f].value}}else{i["filtervalue"+d]=c[f].value}i["filtercondition"+d]=c[f].condition;i["filteroperator"+d]=c[f].operator;i["filterdatafield"+d]=e;i["filtertype"+d]=c[f].type;d++}}}i.filterscount=d;h.filters=i;h.groups=this.groups;h.columns={};var k=0;if(this.columns.records){a.each(this.columns.records,function(m,r){if(!this.datafield){return true}var s={};s.width=this.width;if(this._percentagewidth){s.width=this._percentagewidth}s.hidden=this.hidden;s.pinned=this.pinned;s.groupable=this.groupable;s.resizable=this.resizable;s.draggable=this.draggable;s.text=this.text;s.align=this.align;s.cellsalign=this.cellsalign;s.index=k++;h.columns[this.datafield]=s})}return h},_stringify:function(e){if(window.JSON&&typeof window.JSON.stringify==="function"){var d=this;var c="";try{c=window.JSON.stringify(e)}catch(b){return d._str("",{"":e})}return c}var c=this._str("",{"":e});return c},_quote:function(b){var d=/[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,c={"\b":"\\b","\t":"\\t","\n":"\\n","\f":"\\f","\r":"\\r",'"':'\\"',"\\":"\\\\"};return'"'+b.replace(d,function(e){var f=c[e];return typeof f==="string"?f:"\\u"+("0000"+e.charCodeAt(0).toString(16)).slice(-4)})+'"'},_stringifyArray:function(e){var b=e.length,c=[],d;for(var d=0;d<b;d++){c.push(this._str(d,e)||"null")}return"["+c.join(",")+"]"},_stringifyObject:function(f){var c=[],d,b;var e=this;for(d in f){if(Object.prototype.hasOwnProperty.call(f,d)){b=e._str(d,f);if(b){c.push(e._quote(d)+":"+b)}}}return"{"+c.join(",")+"}"},_stringifyReference:function(b){switch(Object.prototype.toString.call(b)){case"[object Array]":return this._stringifyArray(b)}return this._stringifyObject(b)},_stringifyPrimitive:function(c,b){switch(b){case"string":return this._quote(c);case"number":return isFinite(c)?c:"null";case"boolean":return c}return"null"},_str:function(c,b){var e=b[c],d=typeof e;if(e&&typeof e==="object"&&typeof e.toJSON==="function"){e=e.toJSON(c);d=typeof e}if(/(number|string|boolean)/.test(d)||(!e&&d==="object")){return this._stringifyPrimitive(e,d)}else{return this._stringifyReference(e)}}})})(jqxBaseFramework);
