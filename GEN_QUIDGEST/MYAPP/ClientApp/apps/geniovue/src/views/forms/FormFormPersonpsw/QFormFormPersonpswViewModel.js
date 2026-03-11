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
			name: 'FORM_PERSONPSW',
			area: 'PERSONPSW',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Form_personpsw',
				updateFilesTickets: 'UpdateFilesTicketsForm_personpsw',
				setFile: 'SetFileForm_personpsw'
			}
		})

		/** The primary key. */
		this.ValCodpersonpsw = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpersonpsw',
			originId: 'ValCodpersonpsw',
			area: 'PERSONPSW',
			field: 'CODPERSONPSW',
			description: '',
		}).cloneFrom(values?.ValCodpersonpsw))
		this.stopWatchers.push(watch(() => this.ValCodpersonpsw.value, (newValue, oldValue) => this.onUpdate('personpsw.codpersonpsw', this.ValCodpersonpsw, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpsw = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpsw',
			originId: 'ValCodpsw',
			area: 'PERSONPSW',
			field: 'CODPSW',
			relatedArea: 'PSW',
			description: computed(() => this.Resources.PSW13972),
		}).cloneFrom(values?.ValCodpsw))
		this.stopWatchers.push(watch(() => this.ValCodpsw.value, (newValue, oldValue) => this.onUpdate('personpsw.codpsw', this.ValCodpsw, newValue, oldValue)))

		this.ValCodperson = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperson',
			originId: 'ValCodperson',
			area: 'PERSONPSW',
			field: 'CODPERSON',
			relatedArea: 'PERSON',
			description: computed(() => this.Resources.PERSON00920),
		}).cloneFrom(values?.ValCodperson))
		this.stopWatchers.push(watch(() => this.ValCodperson.value, (newValue, oldValue) => this.onUpdate('personpsw.codperson', this.ValCodperson, newValue, oldValue)))

		/** The remaining form fields. */
		this.TablePswNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePswNome',
			originId: 'ValNome',
			area: 'PSW',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePswNome))
		this.stopWatchers.push(watch(() => this.TablePswNome.value, (newValue, oldValue) => this.onUpdate('psw.nome', this.TablePswNome, newValue, oldValue)))

		this.TablePersonName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePersonName',
			originId: 'ValName',
			area: 'PERSON',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePersonName))
		this.stopWatchers.push(watch(() => this.TablePersonName.value, (newValue, oldValue) => this.onUpdate('person.name', this.TablePersonName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFormPersonpswViewModel instance.
	 * @returns {QFormFormPersonpswViewModel} A new instance of QFormFormPersonpswViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpersonpsw'

	get QPrimaryKey() { return this.ValCodpersonpsw.value }
	set QPrimaryKey(value) { this.ValCodpersonpsw.updateValue(value) }
}
