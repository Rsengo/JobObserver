import BaseApiModel from '../../../../services/baseApiModel'
import Controllers from '../../../../settings/controllers';

const controller = Controllers.Resume;

class resumeApiModel extends BaseApiModel {
    constructor() {
        super();
        this._controller = controller;
    }
}

export default new resumeApiModel()