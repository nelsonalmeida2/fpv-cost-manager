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
			name: 'W_FAVSTORES',
			area: 'INVOICE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_W_favstores',
				updateFilesTickets: 'UpdateFilesTicketsW_favstores',
				setFile: 'SetFileW_favstores'
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

		/** The hidden foreign keys. */
		this.ValCodperson = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'INVOICE',
			field: 'CODPERSON',
			relatedArea: 'PERSON',
			isFixed: true,
			description: computed(() => this.Resources.CODPERSON27649),
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('invoice.codperson', this.ValCodperson, newValue, oldValue)))

		this.ValStore = reactive(new modelFieldType.ForeignKey({
			id: 'ValStore',
			originId: 'ValStore',
			area: 'INVOICE',
			field: 'STORE',
			relatedArea: 'STORE',
			isFixed: true,
			description: computed(() => this.Resources.STORE16493),
		}).cloneFrom(values?.ValStore))
		this.stopWatchers.push(watch(() => this.ValStore.value, (newValue, oldValue) => this.onUpdate('invoice.store', this.ValStore, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValCodinvoicestore = reactive(new modelFieldType.String({
			id: 'ValCodinvoicestore',
			originId: 'ValCodinvoicestore',
			area: 'INVOICE',
			field: 'CODINVOICESTORE',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.CODINVOICESTORE44054),
		}).cloneFrom(values?.ValCodinvoicestore))
		this.stopWatchers.push(watch(() => this.ValCodinvoicestore.value, (newValue, oldValue) => this.onUpdate('invoice.codinvoicestore', this.ValCodinvoicestore, newValue, oldValue)))

		this.ValDeliverytype = reactive(new modelFieldType.String({
			id: 'ValDeliverytype',
			originId: 'ValDeliverytype',
			area: 'INVOICE',
			field: 'DELIVERYTYPE',
			maxLength: 1,
			isFixed: true,
			arrayOptions: computed(() => new qProjArrays.QArrayDeliverytype(vm.$getResource).elements),
			description: computed(() => this.Resources.DELIVERY_TYPE53619),
		}).cloneFrom(values?.ValDeliverytype))
		this.stopWatchers.push(watch(() => this.ValDeliverytype.value, (newValue, oldValue) => this.onUpdate('invoice.deliverytype', this.ValDeliverytype, newValue, oldValue)))

		this.ValShippingcost = reactive(new modelFieldType.Number({
			id: 'ValShippingcost',
			originId: 'ValShippingcost',
			area: 'INVOICE',
			field: 'SHIPPINGCOST',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.SHIPPING_COST12785),
		}).cloneFrom(values?.ValShippingcost))
		this.stopWatchers.push(watch(() => this.ValShippingcost.value, (newValue, oldValue) => this.onUpdate('invoice.shippingcost', this.ValShippingcost, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormWFavstoresViewModel instance.
	 * @returns {QFormWFavstoresViewModel} A new instance of QFormWFavstoresViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodinvoice'

	get QPrimaryKey() { return this.ValCodinvoice.value }
	set QPrimaryKey(value) { this.ValCodinvoice.updateValue(value) }
}
