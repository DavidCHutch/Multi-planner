import React from 'react';
import '../../resources/scss/buttons.scss'

const DrawerToggleButton = props => {
    return(
        <button className='toggle-button'>
            <div className='toggle-button__line'/>
            <div className='toggle-button__line'/>
            <div className='toggle-button__line'/>
        </button>
    );
}

export default DrawerToggleButton