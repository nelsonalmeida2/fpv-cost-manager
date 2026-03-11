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
			name: 'FORM_PERSON',
			area: 'PERSON',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_person',
				updateFilesTickets: 'UpdateFilesTicketsForm_person',
				setFile: 'SetFileForm_person'
			}
		})

		/** The primary key. */
		this.ValCodperson = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'PERSON',
			field: 'CODPERSON',
			description: '',
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('person.codperson', this.ValCodperson, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'PERSON',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('person.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'PERSON',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('person.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'PERSON',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('person.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'PERSON',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('person.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PERSON',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('person.photo', this.ValPhoto, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PERSON',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('person.name', this.ValName, newValue, oldValue)))

		this.ValBirthday = reactive(new modelFieldType.Date({
			id: 'ValBirthday',
			originId: 'ValBirthday',
			area: 'PERSON',
			field: 'BIRTHDAY',
			description: computed(() => this.Resources.BIRTHDAY30236),
		}).cloneFrom(values?.ValBirthday))
		this.stopWatchers.push(watch(() => this.ValBirthday.value, (newValue, oldValue) => this.onUpdate('person.birthday', this.ValBirthday, newValue, oldValue)))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PERSON',
			field: 'GENDER',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayGender(vm.$getResource).elements),
			description: computed(() => this.Resources.GENDER44172),
		}).cloneFrom(values?.ValGender))
		this.stopWatchers.push(watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('person.gender', this.ValGender, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'PERSON',
			field: 'EMAIL',
			maxLength: 50,
			maskType: 'EM',
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('person.email', this.ValEmail, newValue, oldValue)))

		this.ValTelephone = reactive(new modelFieldType.Number({
			id: 'ValTelephone',
			originId: 'ValTelephone',
			area: 'PERSON',
			field: 'TELEPHONE',
			maxDigits: 9,
			decimalDigits: 0,
			description: computed(() => this.Resources.TELEPHONE28697),
		}).cloneFrom(values?.ValTelephone))
		this.stopWatchers.push(watch(() => this.ValTelephone.value, (newValue, oldValue) => this.onUpdate('person.telephone', this.ValTelephone, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFormPersonViewModel instance.
	 * @returns {QFormFormPersonViewModel} A new instance of QFormFormPersonViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodperson'

	get QPrimaryKey() { return this.ValCodperson.value }
	set QPrimaryKey(value) { this.ValCodperson.updateValue(value) }
}
