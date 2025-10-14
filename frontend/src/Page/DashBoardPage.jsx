import { Container,Row,Col } from "react-bootstrap"

export default function DashBoardPage(){
    return(
        <>
            <Container>
                <Row>
                    <Col md={8}> 
                    <div  className="bg-white px-3 py-3 rounded shadow">
                        <h5>Your balance summary</h5>
                        <Row>
                            <Col md={4}>Yes</Col>
                            <Col md={4}>No</Col>
                            <Col md={4}>Yes</Col>
                        </Row>
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