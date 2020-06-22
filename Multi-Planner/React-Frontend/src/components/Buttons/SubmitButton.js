import React, { Component } from 'react';

class SubmitButton extends Component{
  render() {
    return (
    <div className={this.props.className}>
        <button
            className='logbtn'
            disabled={this.props.disabled}
            onClick={ () => this.props.onClick()}
        >
            {this.props.text}
        </button>
    </div>
    );
  }
}

export default SubmitButton;
