import React, { Component } from 'react';
import {Container, Row, Col, Card, Form, Button } from "react-bootstrap";
// import { withRouter } from "react-router";
import Sidebar from "../components/Navigation/Dashboard/Sidebar.js";
import { GetUserData } from '../components/Data/UserData';
import '../resources/scss/dashboard.scss'
import SideDrawer from '../components/Navigation/Dashboard/SideDrawer';
import Toolbar from '../components/Navigation/Dashboard/Toolbar';
import Backdrop from '../components/Backdrop/Backdrop';

class DashBoardPage extends Component {
    render(){
        return (
            <>
                {/* <SideDrawer/>
                <Backdrop></Backdrop> */}
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