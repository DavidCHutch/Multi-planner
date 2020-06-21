import React, { Component } from 'react';
import FacebookLoginBtn from 'react-facebook-login/dist/facebook-login-render-props';
import { GetUserData } from '../components/Data/UserData';
import '../resources/scss/buttons.scss';

var facebookSessionData = GetUserData();
var stateData ={
    auth: false,
    userID: '',
    accessToken: '',
    expiresIn: 0,
    name: ''
}


export default class LoginFacebook extends Component{
    constructor(props){
        super(props);
        this.state = stateData;
    }

    async componentClicked(){
    // componentClicked = data => {
        // console.log('Facebook btn clicked', data);
        window.FB.login(function(response) {
            if (response.authResponse) {
                console.log('Welcome!  Fetching your information.... ');
                console.log('Facebook btn clicked', response);
                window.FB.api('/me', function(response) {
                    console.log('Good to see you, ' + response.name + '.');
                });
                stateData.auth = true
                stateData.userID = response.authResponse.userID;
                stateData.accessToken = response.authResponse.accessToken;
                stateData.expiresIn = response.authResponse.expiresIn;
                stateData.name = response.authResponse.name;
                sessionStorage.setItem('FacebookData', JSON.stringify(response));
                fetch('https://localhost:44382/api/login/facebook?userid=' + response.authResponse.userID + '&accessToken=' + response.authResponse.accessToken)
                    .then(res => res.json())
                    .then(
                        // Note: it's important to handle errors here
                        // instead of a catch() block so that we don't swallow
                        // exceptions from actual bugs in components.
                        (error) => {
                            console.log(error);
                        }
                );
                window.location.reload(false);
            } 
            else {
                console.log('User cancelled login or did not fully authorize.');
            }
        });
    }

    responseFacebook = (response) => {
        if(response.status !== 'unknown'){
            this.setState({
                auth: true,
                userID: response.userID,
                accessToken: response.accessToken,
                expiresIn: response.expiresIn,
                name: response.name,
                picture: response.picture.data.url
            });
            sessionStorage.setItem('FacebookData', JSON.stringify(response));
            var elm = document.getElementById('logForm');
            if(elm !== null){
                elm.style.display='none';
            }
            
            fetch('https://localhost:44382/api/login/facebook?userid=' + response.userID + '&accessToken=' + response.accessToken)
            .then(res => res.json())
            .then(
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                  console.log(error);
                }
            );
            this.doRefreshPage()
        }
    }

    render(){
        let facebookData;
        if(this.state.auth){
            facebookData = (
                <div>
                    <h2>Welcome {this.state.name}</h2>
                </div>
                
            )
        }
        else if(facebookSessionData){
            facebookData = (
                <div>
                    <h2>Welcome {facebookSessionData.name}</h2>
                </div>
            )
        }
        else{
            facebookData = (
                <FacebookLoginBtn
                    cssClass={this.props.cssClass}
                    appId="3269841343029131"
                    autoLoad={false}
                    fields="name,email,picture"
                    callback={this.responseFacebook}
                    // textButton={this.props.value}
                    render={() => (
                        <button className='facebookBtn' onClick={this.componentClicked}> 
                            <img 
                                className='facebookBtn__img'
                                src="https://static.xx.fbcdn.net/rsrc.php/v3/yN/r/szGrb_tkxMW.png"
                                alt
                                height="24"
                                width="24"
                            />
                            <p className='facebookBtn__text'>
                                Continue with Facebook
                            </p>
                        </button>
                    )}
                    />
            );
        }

        return(
            <>
                {facebookData}
            </>
        );
    }

}