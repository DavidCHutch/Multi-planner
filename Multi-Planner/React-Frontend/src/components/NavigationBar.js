import React, { Component } from 'react';
import { Nav, Navbar, Form, Button, FormControl, Container } from 'react-bootstrap';
import styled from 'styled-components';
import { GetUserData } from '../components/Data/UserData';
import Logo from '../resources/images/Logo.svg';
import '../resources/scss/header.scss'

const Styles = styled.div`
    .navbar {
        background-color: #24305E;
    }

    .navbar-brand, .navbar-nav .nav-link{
        color: #A8D0E6;

        &:hover{
            color: white;
        }
    }

    .navbar-toggler{
        background-color: #A8D0E6;
    }
`;

class NavigationBar extends Component{
    render(){
        return(
            <div className="headerContainer">
                <Styles>
                    <Navbar className="nav-bar" expand="lg" fixed="top" class="pt-5">
                        <Navbar.Brand href="/"><img
                            alt=""
                            src={Logo}
                            width="30"
                            height="30"
                            className="d-inline-block align-top"
                        />{' '}
                            Multi-planner
                        </Navbar.Brand>
                        <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                        <Navbar.Collapse id="basic-navbar-nav">
                            <Nav className="ml-auto">
                                <Nav.Item><Nav.Link href="/">Home</Nav.Link></Nav.Item>
                                <Nav.Item><Nav.Link href="/contact">Contact</Nav.Link></Nav.Item>
                                {GetUserData() ? <Nav.Item><Nav.Link href="/user">User</Nav.Link></Nav.Item> : <Nav.Item><Nav.Link href="/createUser">Create user</Nav.Link></Nav.Item>}
                                {GetUserData() ? '' : <Nav.Item><Nav.Link href="/login">Login</Nav.Link></Nav.Item>}
                            </Nav>
                            {GetUserData() ? 
                                <Form inline>
                                    <FormControl type="text" placeholder="Search" className="mr-sm-2" />
                                    <Button variant="outline-success">Search</Button>
                                </Form> 
                                : ''
                            }
                        </Navbar.Collapse>
                    </Navbar>
                </Styles>
            </div>
        );
    }
}

export default NavigationBar