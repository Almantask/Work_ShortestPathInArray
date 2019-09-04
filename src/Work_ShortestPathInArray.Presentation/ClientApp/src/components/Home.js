import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <div>
      <div>
        This is the client side (react) implementation of job interview task.
      </div> 
              <br />
              <div>
                  <a>To check react interface for the task and communication with C# API, go to</a><a href="/ArrayPathConfigurator"> Array Path menu.</a>
          </div>
              <br /> 
              <div>
                  <a>More information and full implementation can be found at:</a><a href="https://github.com/Almantask/Work_ShortestPathInArray"> https://github.com/Almantask/Work_ShortestPathInArray</a>
        </div>
          </div>
  );
  }
}
