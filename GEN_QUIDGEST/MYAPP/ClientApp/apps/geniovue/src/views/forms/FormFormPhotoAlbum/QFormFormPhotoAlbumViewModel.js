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
			name: 'FORM_PHOTO_ALBUM',
			area: 'PHOTOALBUM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_photo_album',
				updateFilesTickets: 'UpdateFilesTicketsForm_photo_album',
				setFile: 'SetFileForm_photo_album'
			}
		})

		/** The primary key. */
		this.ValCodphotoalbum = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodphotoalbum',
			originId: 'ValCodphotoalbum',
			area: 'PHOTOALBUM',
			field: 'CODPHOTOALBUM',
			description: '',
		}).cloneFrom(values?.ValCodphotoalbum))
		this.stopWatchers.push(watch(() => this.ValCodphotoalbum.value, (newValue, oldValue) => this.onUpdate('photoalbum.codphotoalbum', this.ValCodphotoalbum, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodperson = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'PHOTOALBUM',
			field: 'CODPERSON',
			relatedArea: 'PERSON',
			isFixed: true,
			description: computed(() => this.Resources.CODPERSON27649),
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('photoalbum.codperson', this.ValCodperson, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValItem = reactive(new modelFieldType.ForeignKey({
			id: 'ValItem',
			originId: 'ValItem',
			area: 'PHOTOALBUM',
			field: 'ITEM',
			relatedArea: 'ITEM',
			description: computed(() => this.Resources.ITEM40802),
		}).cloneFrom(values?.ValItem))
		this.stopWatchers.push(watch(() => this.ValItem.value, (newValue, oldValue) => this.onUpdate('photoalbum.item', this.ValItem, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'PHOTOALBUM',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('photoalbum.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'PHOTOALBUM',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT29089),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('photoalbum.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'PHOTOALBUM',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY17808),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('photoalbum.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'PHOTOALBUM',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('photoalbum.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PHOTOALBUM',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('photoalbum.photo', this.ValPhoto, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PHOTOALBUM',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('photoalbum.title', this.ValTitle, newValue, oldValue)))

		this.TableItemName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableItemName',
			originId: 'ValName',
			area: 'ITEM',
			field: 'NAME',
			maxLength: 255,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableItemName))
		this.stopWatchers.push(watch(() => this.TableItemName.value, (newValue, oldValue) => this.onUpdate('item.name', this.TableItemName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFormPhotoAlbumViewModel instance.
	 * @returns {QFormFormPhotoAlbumViewModel} A new instance of QFormFormPhotoAlbumViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodphotoalbum'

	get QPrimaryKey() { return this.ValCodphotoalbum.value }
	set QPrimaryKey(value) { this.ValCodphotoalbum.updateValue(value) }
}
