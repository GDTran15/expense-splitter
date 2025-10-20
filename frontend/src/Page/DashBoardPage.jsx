import Chart from "../Component/Chart";
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"

export default function DashBoardPage(){
    const user = JSON.parse(localStorage.getItem("user"));

    return(
        <>
            <Container>
                <Row>
                    <Col md={12}> 
                        <div  className="bg-white px-3 py-3 rounded shadow" style={{minHeight: "420px"}}>
                            <h5>Your Expenses Summary</h5>      
                            <Chart />                 
                        </div>
                    </Col>
                    <Col md={4}>
                        <div className="">                            
                        </div>
                    </Col>
                </Row>
            </Container>
        </>
    )
}