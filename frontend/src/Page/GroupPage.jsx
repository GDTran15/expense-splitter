import { useState } from "react"
import { Container,Row,Col,Button,Modal,Form } from "react-bootstrap"


export default function GroupPage(){
    const [show,setShow] = useState(false);
    return(
        <>
        <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold">Your Groups</h5>
                    <Button size="sm" className="fw-bold rounded py-1 px-3"
                    onClick={() => setShow(true)}
                    >Create New Group</Button>
                </Col>
            </Row>
        </Container>

         <Modal
      show={show}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
      onHide={() => setShow(false)}
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Create New Group
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
         <Form>
            <Form.Group className="mb-3">
              <Form.Label>Group Name</Form.Label>
              <Form.Control
                type="text"
                placeholder="e.g Trip"
                autoFocus
              />
            </Form.Group>
          </Form>
      </Modal.Body>
      <Modal.Footer className="d-flex gap-2">
        <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
        <Button onClick={() => setShow(false)} className="flex-fill">Create</Button>
      </Modal.Footer>
    </Modal>
        </>
    )
}