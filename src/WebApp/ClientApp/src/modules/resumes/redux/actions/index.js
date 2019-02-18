import resumeApiModel from '../api/'

const actionTypes = {
    ADD_RESUME: 'ADD_RESUME',
    LOAD_USER_RESUMES: 'LOAD_RESUMES',
    LOAD_ALL_RESUMES: 'LOAD_ALL_RESUMES',
    LOAD_RESUMES_SUCCESS: 'LOAD_RESUMES_SUCCESS',
}

function addResume(values) {
    //TODO:Здесь в values приходит 6 аргументов, по ним нужно отправить запрос на добавление в бд нового резюме,
    //затем мы вызываем экшен loadUserResumes и получаем список резюме с только что добавленным
    // const userResume = [
    //     {
    //         title: 'Резюме 1',
    //         additional_info: 'information',
    //         is_premial: true,
    //         area_id: 15,
    //         area: {
    //             name: 'пися'
    //         }
    //     },
    //     {
    //         title: 'Резюме 2',
    //         additional_info: 'information2',
    //         is_premial: false,
    //         area_id: 115,
    //         area: {
    //             name: 'пися2'
    //         }
    //     },
    // ];

    return dispatch => {
        return resumeApiModel.save(values).then(returnedResume => {
            dispatch(loadAllResumes())
        });
    }
}

function loadUserResumes(userId) {

    //TODO:Запрос на получение всех резюме по айди соискателя (userId) Должен присвоить переменной userResume полученные резюме
    const userResume = [];
    return {
        type: actionTypes.LOAD_RESUMES_SUCCESS,
        payload: userResume,
    }
}

function loadAllResumes() {
    return (dispatch) => {
        return resumeApiModel.get().then(allResumes => {
                dispatch({type: actionTypes.LOAD_RESUMES_SUCCESS,
                payload: allResumes.data})
        });
    }
}

export {
    actionTypes,
    addResume,
    loadUserResumes,
    loadAllResumes
}