import React from 'react';
import '../../../resources/scss/sidedrawer.scss';

const SideDrawer = (props) => {
    return(
        <nav className='side-drawer'>
            <ul>
                <li><a href='/'>About</a></li>
                <li><a href='/'>Contact</a></li>
            </ul>
        </nav>
    );
}

export default SideDrawer;