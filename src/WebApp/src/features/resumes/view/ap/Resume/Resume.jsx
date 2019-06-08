import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import Input from 'components/Input/desktop';
import Button from 'components/Button/desktop';
import Selector from 'components/Selector/desktop';
import { actions as resumeActions } from '../../../redux';

import './Resume.scss';

class Resume extends React.Component {

  state = {
    area: null,
    applicant_id: null,
    title: null,
    salary: null,
    has_vehicle: false,
    resume_status_id: null,
    travel_time_id: null,
  }

  static propTypes = {
    resumeID: PropTypes.number.isRequired,
    loadResumeByID: PropTypes.func.isRequired,
    resume: PropTypes.object.isRequired,
    dictionaries: PropTypes.object.isRequired,
    updateResume: PropTypes.func.isRequired,
  }

  componentWillMount() {
    const { loadResumeByID, resumeID } = this.props;
    loadResumeByID(resumeID);
  }

  componentWillReceiveProps(nextProps) {
    const { resume } = this.props;
    if (Object.keys(resume).length === 0 && Object.keys(nextProps.resume).length !== 0) {
      Object.keys(this.state).map(tempKey => this.setState({ [tempKey]: nextProps.resume[tempKey] }));
    }
  }

  onResumeUpdate = () => {
    const { updateResume, resumeID, resume } = this.props;
    let newResume = resume;
    Object.keys(this.state).forEach(temp => {
      newResume = { ...newResume, [temp]: this.state[temp] };
    });
    console.log(newResume)
    updateResume(resumeID, newResume);
  }

  onChangeState = (name, value) => this.setState({ [name]: value });

  onChangeListener = e => this.setState({ [e.currentTarget.name]: e.currentTarget.value });

  render() {
    const b = block('resume');
    const { resumeID, resume, dictionaries } = this.props;
    const { area, applicant_id, title, salary, has_vehicle, resume_status_id, travel_time_id } = this.state;
    return (
      <div className={b()}>
        {Object.keys(resume).length !== 0 &&
          <React.Fragment>
            {this.createInput('Название', 'title')}
            {this.createSelector(dictionaries.travel_times, 'travel_time_id', 'Время до работы')}
            {this.createDisabledInput('Статус резюме', this.state.resume_status_id)}
            <Button
              callBack={this.onResumeUpdate}
              text="Обновить резюме"
              size="low" />
          </React.Fragment>
        }
      </div>
    );
  }

  createSelector = (dictionary, propName, text) => (<Selector itemsList={dictionary}
    activeID={this.state[propName]}
    callBack={this.onChangeState}
    label={text}
    name={propName}
    size="big"
    key={propName} />)

  createInput = (label, propName) => (<Input
    value={this.state[propName]}
    name={propName}
    callBack={this.onChangeListener}
    label={label}
    size="high"
  />)

  createDisabledInput = (label, value) => (<Input
    value={value}
    label={label}
    size="high"
    disabled={true}
  />)
}

function mapStateToProps(state) {
  return {
    resume: state.resume.resume,
    dictionaries: state.userSettings.dictionaries,
  };
}

function mapDispatchToProps(dispatch) {
  const actions = {
    ...resumeActions,
  };
  return bindActionCreators(actions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(Resume);