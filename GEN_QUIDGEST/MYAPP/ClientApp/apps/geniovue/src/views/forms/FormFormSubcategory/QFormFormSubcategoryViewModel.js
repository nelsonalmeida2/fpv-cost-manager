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
			name: 'FORM_SUBCATEGORY',
			area: 'SUBCATEGORY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_subcategory',
				updateFilesTickets: 'UpdateFilesTicketsForm_subcategory',
				setFile: 'SetFileForm_subcategory'
			}
		})

		/** The primary key. */
		this.ValCodsubcategory = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodsubcategory',
			originId: 'ValCodsubcategory',
			area: 'SUBCATEGORY',
			field: 'CODSUBCATEGORY',
			description: '',
		}).cloneFrom(values?.ValCodsubcategory))
		this.stopWatchers.push(watch(() => this.ValCodsubcategory.value, (newValue, oldValue) => this.onUpdate('subcategory.codsubcategory', this.ValCodsubcategory, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCategory = reactive(new modelFieldType.ForeignKey({
			id: 'ValCategory',
			originId: 'ValCategory',
			area: 'SUBCATEGORY',
			field: 'CATEGORY',
			relatedArea: 'CATEGORY',
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory))
		this.stopWatchers.push(watch(() => this.ValCategory.value, (newValue, oldValue) => this.onUpdate('subcategory.category', this.ValCategory, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'SUBCATEGORY',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('subcategory.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'SUBCATEGORY',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('subcategory.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'SUBCATEGORY',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('subcategory.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'SUBCATEGORY',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('subcategory.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'SUBCATEGORY',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('subcategory.name', this.ValName, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.String({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'SUBCATEGORY',
			field: 'DESCRIPTION',
			maxLength: 255,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('subcategory.description', this.ValDescription, newValue, oldValue)))

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
	}

	/**
	 * Creates a clone of the current QFormFormSubcategoryViewModel instance.
	 * @returns {QFormFormSubcategoryViewModel} A new instance of QFormFormSubcategoryViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodsubcategory'

	get QPrimaryKey() { return this.ValCodsubcategory.value }
	set QPrimaryKey(value) { this.ValCodsubcategory.updateValue(value) }
}
