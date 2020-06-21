import React, { Component } from 'react';
import {Container, Row, Col, Card, Form, Button } from "react-bootstrap";
// import { withRouter } from "react-router";
import Sidebar from "../components/Menu/sidebar.js";
import { GetUserData } from '../components/Data/UserData';
import '../resources/scss/dashboard.scss'

class DashBoardPage extends Component {
    render(){
        return (
            <>
                <Container fluid>
                    <Row>
                        <Col xs={2} id="sidebar-wrapper">      
                            <Sidebar/>
                        </Col>
                        <Col  xs={10} id="page-content-wrapper">
                            <Card>
                                <h1>tada</h1>
                            </Card>
                        </Col> 
                    </Row>
                </Container>
            </>
            
        );
    }
}

export default DashBoardPage;