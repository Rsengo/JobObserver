import Axios from "axios";

class BaseApiModel {
    constructor() {
        this._controller = null;
    }

    get controller() {
        return this._controller;
    }

    get(id) {
        let errorMessage = this._checkControllerEnabled(this._controller);
        if (errorMessage) {
            throw new Error(errorMessage);
        }
        let idParam = id || "";
        let url = `api/${this._controller}/${idParam}`;
        return Axios.get(url);
    }

    save(obj) {
        let errorMessage = this._checkControllerEnabled(this._controller);
        if (errorMessage) {
            throw new Error(errorMessage);
        }
        if (!obj) {
            throw new Error("Не передан объект для сохранения.");
        }
        let url = `api/${this._controller}`;
        return Axios.post(url, obj);
    }

    update(obj, id) {
        let errorMessage = this._checkControllerEnabled(this._controller);
        if (errorMessage) {
            throw new Error(errorMessage);
        }
        if (!obj) {
            throw new Error("Не передан объект для обновления.");
        }
        let url = `api/${this._controller}/${id}`;
        return Axios.put(url, obj);
    }

    delete(id) {
        let errorMessage = this._checkControllerEnabled(this._controller);
        if (errorMessage) {
            throw new Error(errorMessage);
        }
        if (id === null) {
            throw new Error("Не передан Id сущности для удаления");
        }
        let url = `api/${this._controller}/${id}`;
        return Axios.delete(url);
    }

    _checkControllerEnabled(controller) {
        if (!controller) {
            return "Контроллер не задан.";
        }
        return void "Нет ошибок.";
    }
}

export default BaseApiModel