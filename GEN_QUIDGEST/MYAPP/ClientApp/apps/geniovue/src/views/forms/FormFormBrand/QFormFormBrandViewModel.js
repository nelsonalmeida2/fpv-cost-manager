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
			name: 'FORM_BRAND',
			area: 'BRAND',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_brand',
				updateFilesTickets: 'UpdateFilesTicketsForm_brand',
				setFile: 'SetFileForm_brand'
			}
		})

		/** The primary key. */
		this.ValCodbrand = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodbrand',
			originId: 'ValCodbrand',
			area: 'BRAND',
			field: 'CODBRAND',
			description: '',
		}).cloneFrom(values?.ValCodbrand))
		this.stopWatchers.push(watch(() => this.ValCodbrand.value, (newValue, oldValue) => this.onUpdate('brand.codbrand', this.ValCodbrand, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodperson = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'BRAND',
			field: 'CODPERSON',
			relatedArea: 'PERSON',
			isFixed: true,
			description: computed(() => this.Resources.CODPERSON27649),
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('brand.codperson', this.ValCodperson, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCountry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCountry',
			originId: 'ValCountry',
			area: 'BRAND',
			field: 'COUNTRY',
			relatedArea: 'COUNTRY',
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.ValCountry))
		this.stopWatchers.push(watch(() => this.ValCountry.value, (newValue, oldValue) => this.onUpdate('brand.country', this.ValCountry, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValLogotype = reactive(new modelFieldType.Image({
			id: 'ValLogotype',
			originId: 'ValLogotype',
			area: 'BRAND',
			field: 'LOGOTYPE',
			description: computed(() => this.Resources.LOGOTYPE44505),
		}).cloneFrom(values?.ValLogotype))
		this.stopWatchers.push(watch(() => this.ValLogotype.value, (newValue, oldValue) => this.onUpdate('brand.logotype', this.ValLogotype, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'BRAND',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('brand.name', this.ValName, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.String({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'BRAND',
			field: 'DESCRIPTION',
			maxLength: 255,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('brand.description', this.ValDescription, newValue, oldValue)))

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
			area: 'BRAND',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('brand.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'BRAND',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('brand.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'BRAND',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('brand.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'BRAND',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('brand.updated_at', this.ValUpdated_at, newValue, oldValue)))

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
	 * Creates a clone of the current QFormFormBrandViewModel instance.
	 * @returns {QFormFormBrandViewModel} A new instance of QFormFormBrandViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodbrand'

	get QPrimaryKey() { return this.ValCodbrand.value }
	set QPrimaryKey(value) { this.ValCodbrand.updateValue(value) }
}
