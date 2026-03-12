/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'FORM_ITEM',
			area: 'ITEM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_item',
				updateFilesTickets: 'UpdateFilesTicketsForm_item',
				setFile: 'SetFileForm_item'
			}
		})

		/** The primary key. */
		this.ValCoditem = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'ITEM',
			field: 'CODITEM',
			description: '',
		}).cloneFrom(values?.ValCoditem))
		this.stopWatchers.push(watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('item.coditem', this.ValCoditem, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodperson = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'ITEM',
			field: 'CODPERSON',
			relatedArea: 'PERSON',
			isFixed: true,
			description: computed(() => this.Resources.CODPERSON27649),
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('item.codperson', this.ValCodperson, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValInvoice = reactive(new modelFieldType.ForeignKey({
			id: 'ValInvoice',
			originId: 'ValInvoice',
			area: 'ITEM',
			field: 'INVOICE',
			relatedArea: 'INVOICE',
			description: computed(() => this.Resources.INVOICE63068),
		}).cloneFrom(values?.ValInvoice))
		this.stopWatchers.push(watch(() => this.ValInvoice.value, (newValue, oldValue) => this.onUpdate('item.invoice', this.ValInvoice, newValue, oldValue)))

		this.ValBrand = reactive(new modelFieldType.ForeignKey({
			id: 'ValBrand',
			originId: 'ValBrand',
			area: 'ITEM',
			field: 'BRAND',
			relatedArea: 'BRAND',
			description: computed(() => this.Resources.BRAND05002),
		}).cloneFrom(values?.ValBrand))
		this.stopWatchers.push(watch(() => this.ValBrand.value, (newValue, oldValue) => this.onUpdate('item.brand', this.ValBrand, newValue, oldValue)))

		this.ValCategory = reactive(new modelFieldType.ForeignKey({
			id: 'ValCategory',
			originId: 'ValCategory',
			area: 'ITEM',
			field: 'CATEGORY',
			relatedArea: 'CATEGORY',
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory))
		this.stopWatchers.push(watch(() => this.ValCategory.value, (newValue, oldValue) => this.onUpdate('item.category', this.ValCategory, newValue, oldValue)))

		this.ValSubcategory = reactive(new modelFieldType.ForeignKey({
			id: 'ValSubcategory',
			originId: 'ValSubcategory',
			area: 'ITEM',
			field: 'SUBCATEGORY',
			relatedArea: 'SUBCATEGORY',
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: !isEmptyG([ITEM->CATEGORY])
					return !(this.ValCategory.value === '')
				},
				dependencyEvents: ['fieldChange:item.category'],
				isServerRecalc: false,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources.SUB_CATEGORY39956),
		}).cloneFrom(values?.ValSubcategory))
		this.stopWatchers.push(watch(() => this.ValSubcategory.value, (newValue, oldValue) => this.onUpdate('item.subcategory', this.ValSubcategory, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'ITEM',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('item.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'ITEM',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('item.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'ITEM',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('item.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'ITEM',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('item.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.TableInvoiceCodinvoicestore = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableInvoiceCodinvoicestore',
			originId: 'ValCodinvoicestore',
			area: 'INVOICE',
			field: 'CODINVOICESTORE',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.CODINVOICESTORE44054),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableInvoiceCodinvoicestore))
		this.stopWatchers.push(watch(() => this.TableInvoiceCodinvoicestore.value, (newValue, oldValue) => this.onUpdate('invoice.codinvoicestore', this.TableInvoiceCodinvoicestore, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ITEM',
			field: 'NAME',
			maxLength: 255,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('item.name', this.ValName, newValue, oldValue)))

		this.ValQuantity = reactive(new modelFieldType.Number({
			id: 'ValQuantity',
			originId: 'ValQuantity',
			area: 'ITEM',
			field: 'QUANTITY',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.QUANTITY06415),
		}).cloneFrom(values?.ValQuantity))
		this.stopWatchers.push(watch(() => this.ValQuantity.value, (newValue, oldValue) => this.onUpdate('item.quantity', this.ValQuantity, newValue, oldValue)))

		this.ValUnitprice = reactive(new modelFieldType.Number({
			id: 'ValUnitprice',
			originId: 'ValUnitprice',
			area: 'ITEM',
			field: 'UNITPRICE',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.UNIT_PRICE24898),
		}).cloneFrom(values?.ValUnitprice))
		this.stopWatchers.push(watch(() => this.ValUnitprice.value, (newValue, oldValue) => this.onUpdate('item.unitprice', this.ValUnitprice, newValue, oldValue)))

		this.ValTotalprice = reactive(new modelFieldType.Number({
			id: 'ValTotalprice',
			originId: 'ValTotalprice',
			area: 'ITEM',
			field: 'TOTALPRICE',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [ITEM->QUANTITY] * [ITEM->UNITPRICE]
					return this.ValQuantity.value*this.ValUnitprice.value
				},
				dependencyEvents: ['fieldChange:item.quantity', 'fieldChange:item.unitprice'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [ITEM->UNITPRICE]!= 0 && [ITEM->QUANTITY]!= 0
					return this.ValUnitprice.value!==0&&this.ValQuantity.value!==0
				},
				dependencyEvents: ['fieldChange:item.unitprice', 'fieldChange:item.quantity'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.TOTAL_PRICE46894),
		}).cloneFrom(values?.ValTotalprice))
		this.stopWatchers.push(watch(() => this.ValTotalprice.value, (newValue, oldValue) => this.onUpdate('item.totalprice', this.ValTotalprice, newValue, oldValue)))

		this.TableBrandName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableBrandName',
			originId: 'ValName',
			area: 'BRAND',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableBrandName))
		this.stopWatchers.push(watch(() => this.TableBrandName.value, (newValue, oldValue) => this.onUpdate('brand.name', this.TableBrandName, newValue, oldValue)))

		this.TableCategoryName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCategoryName',
			originId: 'ValName',
			area: 'CATEGORY',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCategoryName))
		this.stopWatchers.push(watch(() => this.TableCategoryName.value, (newValue, oldValue) => this.onUpdate('category.name', this.TableCategoryName, newValue, oldValue)))

		this.TableSubcategoryName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableSubcategoryName',
			originId: 'ValName',
			area: 'SUBCATEGORY',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableSubcategoryName))
		this.stopWatchers.push(watch(() => this.TableSubcategoryName.value, (newValue, oldValue) => this.onUpdate('subcategory.name', this.TableSubcategoryName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFormItemViewModel instance.
	 * @returns {QFormFormItemViewModel} A new instance of QFormFormItemViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoditem'

	get QPrimaryKey() { return this.ValCoditem.value }
	set QPrimaryKey(value) { this.ValCoditem.updateValue(value) }
}
