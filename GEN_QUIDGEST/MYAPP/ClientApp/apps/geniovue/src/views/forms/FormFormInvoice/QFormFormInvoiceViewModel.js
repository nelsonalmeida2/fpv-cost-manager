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
			name: 'FORM_INVOICE',
			area: 'INVOICE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_invoice',
				updateFilesTickets: 'UpdateFilesTicketsForm_invoice',
				setFile: 'SetFileForm_invoice'
			}
		})

		/** The primary key. */
		this.ValCodinvoice = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodinvoice',
			originId: 'ValCodinvoice',
			area: 'INVOICE',
			field: 'CODINVOICE',
			description: '',
		}).cloneFrom(values?.ValCodinvoice))
		this.stopWatchers.push(watch(() => this.ValCodinvoice.value, (newValue, oldValue) => this.onUpdate('invoice.codinvoice', this.ValCodinvoice, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodperson = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'INVOICE',
			field: 'CODPERSON',
			relatedArea: 'PERSON',
			description: computed(() => this.Resources.CODPERSON27649),
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('invoice.codperson', this.ValCodperson, newValue, oldValue)))

		this.ValStore = reactive(new modelFieldType.ForeignKey({
			id: 'ValStore',
			originId: 'ValStore',
			area: 'INVOICE',
			field: 'STORE',
			relatedArea: 'STORE',
			description: computed(() => this.Resources.STORE16493),
		}).cloneFrom(values?.ValStore))
		this.stopWatchers.push(watch(() => this.ValStore.value, (newValue, oldValue) => this.onUpdate('invoice.store', this.ValStore, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'INVOICE',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('invoice.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'INVOICE',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('invoice.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'INVOICE',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('invoice.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'INVOICE',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('invoice.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.TablePersonName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePersonName',
			originId: 'ValName',
			area: 'PERSON',
			field: 'NAME',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePersonName))
		this.stopWatchers.push(watch(() => this.TablePersonName.value, (newValue, oldValue) => this.onUpdate('person.name', this.TablePersonName, newValue, oldValue)))

		this.ValCodinvoicestore = reactive(new modelFieldType.String({
			id: 'ValCodinvoicestore',
			originId: 'ValCodinvoicestore',
			area: 'INVOICE',
			field: 'CODINVOICESTORE',
			maxLength: 50,
			description: computed(() => this.Resources.CODINVOICESTORE44054),
		}).cloneFrom(values?.ValCodinvoicestore))
		this.stopWatchers.push(watch(() => this.ValCodinvoicestore.value, (newValue, oldValue) => this.onUpdate('invoice.codinvoicestore', this.ValCodinvoicestore, newValue, oldValue)))

		this.ValReceipt = reactive(new modelFieldType.Document({
			id: 'ValReceipt',
			originId: 'ValReceipt',
			area: 'INVOICE',
			field: 'RECEIPT',
			properties: computed(() => this.ValReceiptPropertiesVM),
			documentFK: computed(() => this.ValReceiptfk),
			currentDocument: computed(() => this.ValReceiptData),
			description: computed(() => this.Resources.RECEIPT15218),
		}).cloneFrom(values?.ValReceipt))
		this.stopWatchers.push(watch(() => this.ValReceipt.value, (newValue, oldValue) => this.onUpdate('invoice.receipt', this.ValReceipt, newValue, oldValue)))

		this.ValReceiptPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValReceiptPropertiesVM',
			area: 'INVOICE',
			field: 'RECEIPTDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValReceiptPropertiesVM))
		this.ValReceiptfk = reactive(new modelFieldType.String({
			id: 'ValReceiptfk',
			area: 'INVOICE',
			field: 'RECEIPTFK'
		}).cloneFrom(values?.ValReceiptfk))
		this.stopWatchers.push(watch(() => this.ValReceiptfk.value, (newValue, oldValue) => this.onUpdate('invoice.receiptfk', this.ValReceiptfk, newValue, oldValue)))

		this.ValReceiptData = reactive(new modelFieldType.DocumentData({
			id: 'ValReceiptData',
			area: 'INVOICE',
			field: 'RECEIPTDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValReceiptData))
		this.stopWatchers.push(watch(() => this.ValReceiptData.value, (newValue, oldValue) => this.onUpdate('invoice.receiptdata', this.ValReceiptData, newValue, oldValue), { deep: true }))

		this.TableStoreName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableStoreName',
			originId: 'ValName',
			area: 'STORE',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableStoreName))
		this.stopWatchers.push(watch(() => this.TableStoreName.value, (newValue, oldValue) => this.onUpdate('store.name', this.TableStoreName, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'INVOICE',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('invoice.date', this.ValDate, newValue, oldValue)))

		this.ValPrice = reactive(new modelFieldType.Number({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'INVOICE',
			field: 'PRICE',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.PRICE06900),
		}).cloneFrom(values?.ValPrice))
		this.stopWatchers.push(watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('invoice.price', this.ValPrice, newValue, oldValue)))

		this.ValShippingcost = reactive(new modelFieldType.Number({
			id: 'ValShippingcost',
			originId: 'ValShippingcost',
			area: 'INVOICE',
			field: 'SHIPPINGCOST',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.SHIPPING_COST12785),
		}).cloneFrom(values?.ValShippingcost))
		this.stopWatchers.push(watch(() => this.ValShippingcost.value, (newValue, oldValue) => this.onUpdate('invoice.shippingcost', this.ValShippingcost, newValue, oldValue)))

		this.ValTaxes = reactive(new modelFieldType.Number({
			id: 'ValTaxes',
			originId: 'ValTaxes',
			area: 'INVOICE',
			field: 'TAXES',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.TAXES34617),
		}).cloneFrom(values?.ValTaxes))
		this.stopWatchers.push(watch(() => this.ValTaxes.value, (newValue, oldValue) => this.onUpdate('invoice.taxes', this.ValTaxes, newValue, oldValue)))

		this.ValNumberofitems = reactive(new modelFieldType.Number({
			id: 'ValNumberofitems',
			originId: 'ValNumberofitems',
			area: 'INVOICE',
			field: 'NUMBEROFITEMS',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.NUMBER_OF_ITEMS22472),
		}).cloneFrom(values?.ValNumberofitems))
		this.stopWatchers.push(watch(() => this.ValNumberofitems.value, (newValue, oldValue) => this.onUpdate('invoice.numberofitems', this.ValNumberofitems, newValue, oldValue)))

		this.ValTotalprice = reactive(new modelFieldType.Number({
			id: 'ValTotalprice',
			originId: 'ValTotalprice',
			area: 'INVOICE',
			field: 'TOTALPRICE',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [INVOICE->PRICE] + [INVOICE->SHIPPINGCOST] + [INVOICE->TAXES]
					return this.ValPrice.value+this.ValShippingcost.value+this.ValTaxes.value
				},
				dependencyEvents: ['fieldChange:invoice.price', 'fieldChange:invoice.shippingcost', 'fieldChange:invoice.taxes'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [INVOICE->NUMBEROFITEMS]!=0
					return this.ValNumberofitems.value!==0
				},
				dependencyEvents: ['fieldChange:invoice.numberofitems'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.TOTAL_PRICE46894),
		}).cloneFrom(values?.ValTotalprice))
		this.stopWatchers.push(watch(() => this.ValTotalprice.value, (newValue, oldValue) => this.onUpdate('invoice.totalprice', this.ValTotalprice, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFormInvoiceViewModel instance.
	 * @returns {QFormFormInvoiceViewModel} A new instance of QFormFormInvoiceViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodinvoice'

	get QPrimaryKey() { return this.ValCodinvoice.value }
	set QPrimaryKey(value) { this.ValCodinvoice.updateValue(value) }
}
