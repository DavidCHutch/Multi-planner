import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { Dropdown, Container, Row, Col} from 'react-bootstrap';
import CreateUserForm from '../components/Form/CreateUserForm';

const CreateUserPage = () => {
    return (
        <div className="app">
            <div>
                <CreateUserForm/>
            </div>
        </div>
    );
}

export default CreateUserPage;
