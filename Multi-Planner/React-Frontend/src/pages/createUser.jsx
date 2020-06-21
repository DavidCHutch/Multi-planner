import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { Dropdown, Container, Row, Col} from 'react-bootstrap';
import CreateUserForm from '../components/Form/CreateUserForm';
import { GetUserData } from '../components/Data/UserData';

const CreateUserPage = () => {
    return (
        <div className="app">
            <div>
                {GetUserData() ? '' : <CreateUserForm/>}
            </div>
        </div>
    );
}

export default CreateUserPage;
