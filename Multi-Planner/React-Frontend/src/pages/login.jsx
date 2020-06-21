import React, { Component } from 'react';
import { Route, Switch, Redirect, Link } from "react-router-dom";
import { Dropdown, Container, Row, Col} from 'react-bootstrap';
import Facebook from '../components/Facebook';
import LoginForm from '../components/Form/LoginForm';

class LoginPage extends Component{
    render(){
        return (
            <Container className="container d-flex align-items-center">
                <Row className="container__row">
                    <Col className="container__col">
                        <div>
                            <LoginForm/>
                        </div>
                    </Col>
                </Row>
            </Container>
        );
    }
}

export default LoginPage;
