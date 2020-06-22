import React, { Component } from 'react';
import '../../../resources/scss/header.scss';
import DrawerToggleButton from '../../Buttons/DrawerToggleButton';

class Toolbar extends Component {
    
    render(){
        return(
            <header className='toolbar'>
                <nav className='toolbar__navigation'>
                    <div></div>
                    <DrawerToggleButton/>
                    <div className='toolbar__logo'><a href="/">THE LOGO</a></div>
                    <div className='toolbar__spacer'></div>
                    <div className='toolbar__item'>
                        <ul>
                            <li><a href="/">Products</a></li>
                            <li><a href="/">Contact</a></li>
                            <li><a href="/">User</a></li>
                        </ul>
                    </div>
                </nav>
            </header>
        );
    }
}

export default Toolbar