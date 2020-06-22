import React, { Component } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import NavigationBar from './components/Navigation/NavigationBar';
import { GetUserData } from './components/Data/UserData';
import SideDrawer from './components/Navigation/Dashboard/SideDrawer';
import Toolbar from './components/Navigation/Dashboard/Toolbar';

import { 
  BrowserRouter as Router, 
  Route, 
  Switch, 
  Redirect 
} from "react-router-dom";

//Pages
import MainPage from "./pages";
import ContactPage from "./pages/contact";
import ErrorPage from "./pages/error";
import LoginPage from "./pages/login";
import CreateUserPage from "./pages/createUser";
import DashBoardPage from "./pages/dashBoard";

class App extends Component {  
  render(){
      return (
        <React.Fragment>
          <NavigationBar/>
          {/* <Toolbar/> */}
          <main style={{marginTop: '76px', height:'100%'}}>
          <Router>
              <Switch> 
                {GetUserData() ? <Route exact path="/" component={DashBoardPage}/> : <Route exact path="/" component={MainPage}/>}
                <Route exact path="/contact" component={ContactPage}/>
                <Route exact path="/createUser" component={CreateUserPage}/>
                {GetUserData() ? <Redirect to="/"/> : <Route exact path="/login" component={LoginPage}/> }
                <Route exact path="/error" component={ErrorPage}/>
                <Redirect to="/error"/>
              </Switch>
            </Router>
          </main>
        </React.Fragment>
       );
  }
}

export default App;
