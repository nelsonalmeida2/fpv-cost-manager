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
			name: 'FORM_STORE',
			area: 'STORE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_store',
				updateFilesTickets: 'UpdateFilesTicketsForm_store',
				setFile: 'SetFileForm_store'
			}
		})

		/** The primary key. */
		this.ValCodstore = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodstore',
			originId: 'ValCodstore',
			area: 'STORE',
			field: 'CODSTORE',
			description: '',
		}).cloneFrom(values?.ValCodstore))
		this.stopWatchers.push(watch(() => this.ValCodstore.value, (newValue, oldValue) => this.onUpdate('store.codstore', this.ValCodstore, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodperson = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'STORE',
			field: 'CODPERSON',
			relatedArea: 'PERSON',
			isFixed: true,
			description: computed(() => this.Resources.CODPERSON27649),
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('store.codperson', this.ValCodperson, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCountry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCountry',
			originId: 'ValCountry',
			area: 'STORE',
			field: 'COUNTRY',
			relatedArea: 'COUNTRY',
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.ValCountry))
		this.stopWatchers.push(watch(() => this.ValCountry.value, (newValue, oldValue) => this.onUpdate('store.country', this.ValCountry, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValLogotype = reactive(new modelFieldType.Image({
			id: 'ValLogotype',
			originId: 'ValLogotype',
			area: 'STORE',
			field: 'LOGOTYPE',
			description: computed(() => this.Resources.LOGOTYPE44505),
		}).cloneFrom(values?.ValLogotype))
		this.stopWatchers.push(watch(() => this.ValLogotype.value, (newValue, oldValue) => this.onUpdate('store.logotype', this.ValLogotype, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'STORE',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('store.name', this.ValName, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.String({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'STORE',
			field: 'DESCRIPTION',
			maxLength: 255,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('store.description', this.ValDescription, newValue, oldValue)))

		this.ValSite = reactive(new modelFieldType.String({
			id: 'ValSite',
			originId: 'ValSite',
			area: 'STORE',
			field: 'SITE',
			maxLength: 255,
			description: computed(() => this.Resources.WEBSITE08569),
		}).cloneFrom(values?.ValSite))
		this.stopWatchers.push(watch(() => this.ValSite.value, (newValue, oldValue) => this.onUpdate('store.site', this.ValSite, newValue, oldValue)))

		this.ValCurrency = reactive(new modelFieldType.String({
			id: 'ValCurrency',
			originId: 'ValCurrency',
			area: 'STORE',
			field: 'CURRENCY',
			maxLength: 3,
			arrayOptions: computed(() => new qProjArrays.QArrayCurrency(vm.$getResource).elements),
			description: computed(() => this.Resources.CURRENCY13881),
		}).cloneFrom(values?.ValCurrency))
		this.stopWatchers.push(watch(() => this.ValCurrency.value, (newValue, oldValue) => this.onUpdate('store.currency', this.ValCurrency, newValue, oldValue)))

		this.TableCountryName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCountryName',
			originId: 'ValName',
			area: 'COUNTRY',
			field: 'NAME',
			maxLength: 75,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCountryName))
		this.stopWatchers.push(watch(() => this.TableCountryName.value, (newValue, oldValue) => this.onUpdate('country.name', this.TableCountryName, newValue, oldValue)))

		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'STORE',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('store.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'STORE',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('store.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'STORE',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('store.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'STORE',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('store.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.PersonValName = reactive(new modelFieldType.String({
			id: 'PersonValName',
			originId: 'ValName',
			area: 'PERSON',
			field: 'NAME',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.PersonValName))
		this.stopWatchers.push(watch(() => this.PersonValName.value, (newValue, oldValue) => this.onUpdate('person.name', this.PersonValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFormStoreViewModel instance.
	 * @returns {QFormFormStoreViewModel} A new instance of QFormFormStoreViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodstore'

	get QPrimaryKey() { return this.ValCodstore.value }
	set QPrimaryKey(value) { this.ValCodstore.updateValue(value) }
}
