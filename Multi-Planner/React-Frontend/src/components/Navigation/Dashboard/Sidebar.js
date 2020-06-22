import React, { Component } from 'react';
import { Nav, Navbar, Form, Button, FormControl, Container, Row, Col } from 'react-bootstrap';
import '../../../resources/scss/sidebar.scss';
import Logo from '../../../resources/images/Logo.svg';


class Sidebar extends Component {
    openNav = () => {
        var elm1 = document.getElementById("mySidebar");
        var elm2 = document.getElementById("main");
        
        if(elm1 && elm2){
            console.log('Opening nav bar');
            elm1.style.width = "15%";
            // elm2.style.visibility = "hidden";
            elm2.style.marginLeft = "200px";
        }
    }
      
    closeNav = () => {
        var elm1 = document.getElementById("mySidebar");
        var elm2 = document.getElementById("main");
        if(elm1 && elm2){
            console.log('Closing nav bar');
            elm1.style.width = "0";
            elm2.style.marginLeft= "0";
            elm2.style.visibility = "visible";
        }
    }
    render(){
        return(
            <Container >
                <Nav id="mySidebar" className="sidebar">
                        <Row className='sidebar__item'>
                            <a href="javascript:void(0)" className="closebtn" onClick={() => this.closeNav()}>x</a>                        
                        </Row>
                        <Row className='sidebar__item'>
                            <Nav.Item className='sidebar__item'>
                                <Nav.Link className='sidebar__subItem' href='/contact'>
                                    <img className='sidebar__image' src={Logo} alt='Nothing here mate'/>
                                    <p className='sidebar__text'>About</p>
                                </Nav.Link> */
                            </Nav.Item>
                        </Row>
                        <Row className='sidebar__item'>
                            <Nav.Item className='sidebar__item'>
                                <Nav.Link className='sidebar__subItem' href='/contact'>
                                    <img className='sidebar__image' src={Logo} alt='Nothing here mate'/>
                                    <p className='sidebar__text'>Contact</p>
                                </Nav.Link>
                            </Nav.Item>
                        </Row>            
                </Nav>
                <div id="main">
                    <button className="openbtn" onClick={() => this.openNav()}>☰</button>
                </div>  
            </Container>
        );
    }
}
export default Sidebar;