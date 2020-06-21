import React, { Component } from 'react';

class InputField extends Component{
  render() {
    return (
    <div className={this.props.className}>
        <input
            className={'input'}
            type={this.props.type}
            placeholder={this.props.placeholder}
            value={this.props.value}
            onChange={ (e) => this.props.onChange(e.target.value)}
        />
    </div>
    );
  }
}

export default InputField;
