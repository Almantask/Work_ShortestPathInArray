import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/ArrayPathConfigurator';

const ArrayPath = () => {

    const BindLogicToPhysicalSteps = (stepIndex, step) => {
        const array = arrayPath.slice();

        if (step == null || step == "") {
            array.splice(stepIndex, 1);
        }
        else {
            array[stepIndex] = step;
        }

        setArrayPath(array);
    }

    const addStep = () => {
        const array = arrayPath.slice();
        const defaultStepValue = 0;
        array.push(defaultStepValue);
        setArrayPath(array);

        setIsReachabilityRequest(false);
        setIsShortestPathRequest(false);
    }

    const assignEndStatus = () => {
        setiSEndPossible(true);
        setIsReachabilityRequest(true);
        setIsShortestPathRequest(false);
    }

    const assignShortestPath = () => {
        setShortestPath([0, 1, 2, 3]);
        setIsShortestPathRequest(true);
        setIsReachabilityRequest(false);
    }

    const [arrayPath, setArrayPath] = useState([]);
    const [isEndPossible, setiSEndPossible] = useState(null);
    const [shortestPath, setShortestPath] = useState(null);

    const [isReachabilityRequest, setIsReachabilityRequest] = useState(false);
    const [isShortestPathRequest, setIsShortestPathRequest] = useState(false);

    return (
        <div>
            {arrayPath.map((step, stepIndex) =>
                <InputStep
                    index={stepIndex}
                    onInputStepChange={BindLogicToPhysicalSteps}
                    stepValue={step}
                />
            )}
            <button
                onClick={addStep}>
                Add Step
                </button>
            <br />
            <button
                onClick={assignEndStatus}>
                Is End Reachable
                </button>
            <button
                onClick={assignShortestPath}>
                Find Shortest Path
                </button>
            <br />
            {isReachabilityRequest &&
                <IsEndReachableStatusLabel IsReachable={isEndPossible} />}
            {isShortestPathRequest &&
                <OptimalPathLabel OptimalPath={shortestPath} />}
        </div>
    );
}

const InputStep = (props) => {
    const handleInputChange = (event) => props.onInputStepChange(props.index, event.target.value);

    return (
        <input onInput={handleInputChange.bind(this)} defaultValue={props.stepValue} >
        </input>
    )
}

const IsEndReachableStatusLabel = (props) => {
    const text = props.IsReachable ? "End is reachable." : "End cannot be reached.";
    return <div>{text}</div>
}

const OptimalPathLabel = (props) => {
    return <div>Optimal Path: {props.OptimalPath}.</div>
}

export default connect(
    state => state.counter,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(ArrayPath);
