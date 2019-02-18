import BaseApiModel from '../../../../services/baseApiModel'
import Controllers from '../../../../settings/controllers';

const controller = Controllers.Vacancy;

class vacancyApiModel extends BaseApiModel {
    constructor() {
        super();
        this._controller = controller;
    }
}

export default new vacancyApiModel()