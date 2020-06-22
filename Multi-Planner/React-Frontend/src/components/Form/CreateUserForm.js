import React, { Component } from 'react';
// import ImputField from './InputField';
import SubmitButton from '../Buttons/SubmitButton';
import InputField from '../InputField';
import Facebook from '../Facebook';
import '../../resources/scss/createuserform.scss';

const initialState= {
    fname: '',
    lname: '',
    email:'',
    password: '',
    cpassword: '',
    fnameErr: '',
    emailErr: '',
    passwordErr: '',
    cpasswordErr: '',
    buttonDisabled: false
}

class CreateUserForm extends Component{
  constructor(props){
    super(props);
    this.state = initialState;
  }

  /**
   * Max input length for password and username
   */
  setInputValue(property, val){
    val = val.trim();
    if(val.length > 50){
      return;
    }
    this.setState({
      [property]: val
    })
  }

  async doCreate(){
    let fnameErr = '';
    let emailErr = '';
    let passwordErr = '';
    let cpasswordErr = '';


    if(!this.state.fname || !this.state.lname || !this.state.email || !this.state.password || !this.state.cpassword){
        if(!this.state.fname){
            fnameErr = "Invalid first name";
            console.log('No first name');
        }
        if(!this.state.email || !this.state.email.includes("@")){
            emailErr = "Invalid email";
            console.log('EMAIL NOT VALID');
        }
        if(!this.state.password){
            passwordErr = "Invalid password";
            console.log('No password name');
        }
        if(!this.state.cpassword || this.state.cpassword !== this.state.password){
            cpasswordErr = "Password doesn't match";
            console.log('No check password name');
        }
        this.setState({fnameErr, emailErr, passwordErr, cpasswordErr});
        return;
    }

    this.setState({
      buttonDisabled: true
    })

    try{
        //Call backend api and verify that it doesnt exist, 
      let res = await fetch('/api/login', {
        method: 'post',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          fname: this.state.fname,
          lname: this.state.lname,
          email: this.state.email,
          password: this.state.password
        })
      })

      let result = await res.json();
      if(result && result.success){
        //TODO REDIRECT TO LOGIN PAGE
      }
      else if(result && result.success === false){
        this.setState(initialState);
        alert(result.msg);
      }
    }

    catch(e){
      console.log(e);
      this.setState(initialState);
    }

  }

  render() {
    return (
    <div className="createForm">    
        <div className="createForm__title">
          <h2>Create user</h2>
        </div>    

        <div className="createForm__errorMsg">{this.state.fnameErr}</div>
        <InputField
          className="createForm__field"
          type='text'
          placeholder='First name'
          value={this.state.fname ? this.state.fname : ''}
          onChange={ (val) => this.setInputValue('fname', val) }
        />

        <InputField
          className="createForm__field"
          type='text'
          placeholder='Last name (optional)'
          value={this.state.lname ? this.state.lname : ''}
          onChange={ (val) => this.setInputValue('lname', val) }
        />

        <div className="createForm__errorMsg">{this.state.emailErr}</div>
        <InputField
          className="createForm__field"
          type='text'
          placeholder='Email'
          value={this.state.email ? this.state.email : ''}
          onChange={ (val) => this.setInputValue('email', val) }
        />

        <div className="createForm__errorMsg">{this.state.passwordErr}</div>
        <InputField
          className="createForm__field"
          type='password'
          placeholder='Password'
          value={this.state.password ? this.state.password : ''}
          onChange={ (val) => this.setInputValue('password', val) }
        />

        <div className="createForm__errorMsg">{this.state.cpasswordErr}</div>
        <InputField
          className="createForm__field"
          type='password'
          placeholder='Confirm password'
          value={this.state.cpassword ? this.state.cpassword : ''}
          onChange={ (val) => this.setInputValue('cpassword', val) }
        />

        <SubmitButton
          className="createForm__button"
          text='Sign up for Multi-planner'
          disabled={this.state.buttonDisabled}
          onClick={ () => this.doCreate()}
        />

        <div className="createForm__buttonForeign">
          <Facebook value="Sign up with Facebook"/>
        </div>
    </div>
    );
  }
}

export default CreateUserForm;
