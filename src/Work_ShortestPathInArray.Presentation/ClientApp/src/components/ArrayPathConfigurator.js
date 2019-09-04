import React, { Component } from 'react';

export class ArrayPathConfigurator extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            arrayPath: [],
            isEndPossible: null,
            shortestPath: null,
            isReachabilityRequest: false,
            isShortestPathRequest: false
        }
    }

    bindLogicToPhysicalSteps = (stepIndex, step) => {
        const array = this.state.arrayPath.slice();

        if (step === null || step === "") {
            array.splice(stepIndex, 1);
        }
        else {
            array[stepIndex] = step;
        }

        this.setState({ arrayPath: array });
    }

    addStep = () => {
        const array = this.state.arrayPath.slice();
        const defaultStepValue = 0;
        array.push(defaultStepValue);
        this.setState({ arrayPath: array });
        this.setState({ isReachabilityRequest: false });
        this.setState({ isShortestPathRequest: false });
    }

    assignEndStatus = () => {
        this.setState({ issEndPossible: true }); // to be determined
        this.setState({ isReachabilityRequest: true });
        this.setState({ isShortestPathRequest: false });
    }

    assignShortestPath = () => {
        this.setState({ shortestPath: [0, 1, 2, 3] });
        this.setState({ isReachabilityRequest: false });
        this.setState({ isShortestPathRequest: true });
    }

    render() {
        return (
            <div>
                {this.state.arrayPath.map((step, stepIndex) =>
                    <InputStep
                        index={stepIndex}
                        onInputStepChange={this.bindLogicToPhysicalSteps}
                        stepValue={step}
                    />
                )}
                <button
                    onClick={this.addStep}>
                    Add Step
    </button>
                <br />
                <button
                    onClick={this.assignEndStatus}>
                    Is End Reachable
    </button>
                <button
                    onClick={this.assignShortestPath}>
                    Find Shortest Path
    </button>
                <br />
                {this.state.isReachabilityRequest &&
                    <IsEndReachableStatusLabel isReachable={this.state.isEndPossible} />}
                {this.state.isShortestPathRequest &&
                    <OptimalPathLabel optimalPath={this.state.shortestPath} />}
            </div>
        );
    }
}

export class IsEndReachableStatusLabel extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isReachable: props.isReachable
        }
    }

    render() {
        const text = this.state.isReachable ? "End is reachable." : "End cannot be reached.";
        return <div>{text}</div>
    }
}

export class OptimalPathLabel extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            optimalPath: props.optimalPath
        }
    }

    render() {
        return <div>Optimal Path: {this.state.optimalPath}.</div>;
    }
}

export class InputStep extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            onInputStepChange: props.onInputStepChange,
            index: props.index,
            stepValue: props.stepValue
        }
    }

    handleInputChange = (event) => this.state.onInputStepChange(this.state.index, event.target.value);

    render() {
        return <
            input
            onInput={
                this.handleInputChange.bind(this)
            }
            defaultValue={this.state.stepValue} />
    }
}