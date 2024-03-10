(function (kendo, $) {
	var kendo = window.kendo,
	  ui = kendo.ui,
	  Widget = ui.Widget;

	var CHANGE = "change";

	var ExtCustomDropDownList = kendo.ui.Widget.extend({
		_uid: null,
		_dropdown: null,
		self: null,
		init: function (element, options) {
			var that = this;
			self = this;
			kendo.ui.Widget.fn.init.call(that, element, options);
			that._uid = new Date().getTime();
			this.wrapper = $("<input class='k-textbox codeInput col-sm-3'/>");
			$(element).append(this.wrapper);
			$(element).append(kendo.format("<input id='{0}' name='{0}' class='k-ext-dropdown' {1} />", that.options.name, that.options.htmlAttributes));

			that.template = kendo.template(that.options.template || "<p><strong>#= data #</strong></p>");


			this.wrapper.on("click", self._selectDoroDownItemByCode);
			this.wrapper.on("keypress", self._selectDoroDownItemByCode);

			that._dataSource();
			// Create the dropdown.
			that._dropdown = $(kendo.format("#{0}", that.options.name)).kendoDropDownList({//$(kendo.format("#extDropDown{0}", that._uid))
				dataSource: this.dataSource,
				dataTextField: options.dataTextField,
				dataValueField: options.dataValueField,
				optionLabel: options.optionLabel,
				change: function (e) {
					var index = this.selectedIndex,
					dataItem;
					dataItem = this.dataItem(index);
					var input = $(self.element).find('.codeInput');
					if (dataItem[options.dataCodeField]) {
						input.val(dataItem[options.dataCodeField]);
					}
				},
				dataBound: function (e) {
					console.log("databound: "+that.options.value);
					if (that.options.value) {
						that.value(that.options.value);
					}

				},
				select: function (e) {
					var index = this.selectedIndex,
					dataItem;
					dataItem = this.dataItem(index);
					var input = $(self.element).find('.codeInput');
					if (dataItem[options.dataCodeField]) {
						input.val(dataItem[options.dataCodeField]);
					}
				}
			}).data("kendoDropDownList");
		},

		dropdown: function () {
			return this._dropdown;
		},

		options: {
			name: "ExtCustomDropDownList",
			dataCodeField: "",
			enabled: !0,
			autoBind: !0,
			index: 0,
			text: null,
			value: null,
			dataTextField: "",
			dataValueField: "",
			optionLabel: "",
			template: "",
			htmlAttributes:"",
		},

		_dataSource: function () {
			var that = this;
			// returns the datasource OR creates one if using an array or a configuration
			that.dataSource = kendo.data.DataSource.create(that.options.dataSource);

			// bind to the change event to refresh the widget
			that.dataSource.bind(CHANGE, function () {
				that.refresh();
			});
		},
		//don't work
		refresh: function () {
			var that = this,
				view = that.dataSource.view();
			//var html = kendo.render(that.template, view);
			//that.element.html(html);
		},
		_selectDoroDownItemByCode: function (e) {
			if (e.type != "keypress" || kendo.keys.ENTER == e.keyCode) {

				var text = $(this).val();
				var data = self.dataSource.data();
				if (!$.isNumeric(text)) {//try parse int => search
					self._dropdown.search(text);
				}
				else {

					if (self.options.dataCodeField == "") {
						self._dropdown.select(text);
					}
					else {
						var result = $.grep(data, function (element, index) {
							return element[self.options.dataCodeField] == text;
						});
						if (typeof (result[0]) !== "undefined" && result !== null) {
							self._dropdown.value(result[0][self.options.dataValueField]);
						}
					}
				}
			}
		},
		value: function (value) {
			if (value !== undefined) {
				self._dropdown.value(value);
				var input = $(self.element).find('.codeInput');
				var data = self.dataSource.data();
				var result = $.grep(data, function (element, index) {
					return element[self.options.dataValueField] == value;
				});
				if (typeof (result[0]) !== "undefined" && result !== null) {
					input.val(result[0][self.options.dataCodeField]);
				}
			} else {
				return self._dropdown.val();
			}
		},
	});
	kendo.ui.plugin(ExtCustomDropDownList);
})(window.kendo, window.kendo.jQuery);