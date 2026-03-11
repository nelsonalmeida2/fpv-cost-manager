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
			name: 'FORM_COUNTRY',
			area: 'COUNTRY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_country',
				updateFilesTickets: 'UpdateFilesTicketsForm_country',
				setFile: 'SetFileForm_country'
			}
		})

		/** The primary key. */
		this.ValCodcountry = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcountry',
			originId: 'ValCodcountry',
			area: 'COUNTRY',
			field: 'CODCOUNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcountry))
		this.stopWatchers.push(watch(() => this.ValCodcountry.value, (newValue, oldValue) => this.onUpdate('country.codcountry', this.ValCodcountry, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'COUNTRY',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('country.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'COUNTRY',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('country.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'COUNTRY',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('country.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'COUNTRY',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('country.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'COUNTRY',
			field: 'NAME',
			maxLength: 75,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('country.name', this.ValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFormCountryViewModel instance.
	 * @returns {QFormFormCountryViewModel} A new instance of QFormFormCountryViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcountry'

	get QPrimaryKey() { return this.ValCodcountry.value }
	set QPrimaryKey(value) { this.ValCodcountry.updateValue(value) }
}
