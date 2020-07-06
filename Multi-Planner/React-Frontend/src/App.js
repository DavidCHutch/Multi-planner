import React, { Component } from 'react';
import './App.css';
import Aux from "./hoc/_Aux";

import { 
  BrowserRouter as Router, 
  Route, 
  Switch, 
  Redirect 
} from "react-router-dom";

class App extends Component {  
  render(){
      return (
        <Aux>
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
        </Aux>
       );
  }
}

export default App;
