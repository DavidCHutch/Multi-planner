import React, { Component } from 'react';
import { Container, Row, Col} from 'react-bootstrap';
import PageImage from '../resources/images/TitlePage.png';
import Facebook from '../components/Facebook';
import CreateUserForm from '../components/Form/CreateUserForm';
import '../resources/scss/container.scss';

class MainPage extends Component{
    render(){
        return (
            <Container className="container d-flex align-items-center">
                <Row className="container__row">
                    <Col className="container__col" lg={true}>
                        <h1 className="container__title">Structure your daily life</h1>
                        <p className="container__body">
                            Multi-planner is a scheduling and event platform, that allows you to generate work schedules for your events or company.
                        </p>
                        <img src={PageImage} className="rounded mx-auto sometimes-hidden-img" alt="loading..." width={300}/>
                    </Col>
                    <Col className="container__col">
                        <div>
                            <CreateUserForm/>
                        </div>
                    </Col>
                </Row>
            </Container>
        );
    }
}

export default MainPage;
