import React, { Component } from 'react';
// Be sure to include styles at some point, probably during your bootstraping
import { Container } from 'react-bootstrap';
import '../../resources/scss/sidebar.scss';
import Logo from '../../resources/images/Logo.svg';


class Sidebar extends Component {
    render(){
        return(
            <div className='sidebar'>
                <div className='sidebar__item'>About</div>
                <img className='sidebar__image' src={Logo} alt='Nothing here mate'/>
            </div>
        );
    }
}
export default Sidebar;