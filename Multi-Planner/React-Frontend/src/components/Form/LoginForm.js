import React, { Component } from 'react';
// import ImputField from './InputField';
import SubmitButton from '../Buttons/SubmitButton';
import InputField from '../InputField';
import Facebook from '../Facebook';
import '../../resources/scss/loginform.scss';

class LoginForm extends Component{
  constructor(props){
    super(props);
    this.state = {
      email: '',
      password: '',
      buttonDisabled: false
    }
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

  resetForm(){
    this.setState({
      email: '',
      password: '',
      buttonDisabled: false
    })
  }

  doRefreshPage() {
    window.location.reload(false);
  }

  async doLogin(){
    if(!this.state.email){
      return;
    }
    if(!this.state.password){
      return;
    }

    this.setState({
      buttonDisabled: true
    })

    try{
      let res = await fetch('https://localhost:44382/api/login', {
        method: 'post',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          email: this.state.email,
          password: this.state.password
        })
      })

      let result = await res.json();
      if(result && res.ok){
        sessionStorage.setItem('userName', JSON.stringify(result.name));
        sessionStorage.setItem('userPicture', JSON.stringify(result.picture));
        sessionStorage.setItem('isloggedIn', true);
        //TODO REDIRECT TO MAIN PAGE
      }
      else if(result && res.ok === false){
        this.resetForm();
        alert(result.msg);
      }
      else{
        this.resetForm();
        alert(result.message);
      }
    }

    catch(e){
      console.log(e);
      this.resetForm();
    }

  }

  render() {
    return (
    <div className="loginForm">
        <div className="loginForm__title">
          <h2>Log in</h2>
        </div>
        
        <InputField
          className="loginForm__field"
          type='text'
          placeholder='Email'
          value={this.state.email ? this.state.email : ''}
          onChange={ (val) => this.setInputValue('email', val) }
        />

        <InputField
          className="loginForm__field"
          type='password'
          placeholder='Password'
          value={this.state.password ? this.state.password : ''}
          onChange={ (val) => this.setInputValue('password', val) }
        />

        <SubmitButton
          className="loginForm__button"
          text='Login'
          disabled={this.state.buttonDisabled}
          onClick={ () => this.doLogin()}
        />

        <div className="loginForm__buttonForeign">
          <Facebook value="Sign up with Facebook"/>
        </div>

    </div>
    );
  }
}

export default LoginForm;
