import BaseDictionaryModel from './baseDictionaryModel';
import Controllers from '../settings/controllers'

const controller = Controllers.Industry;

class IndustryApiModel extends BaseDictionaryModel {
    constructor() {
        super();
        this._controller = controller;
    }
}