import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form } from "react-bootstrap"
import GroupComponent from "../Component/GroupComponent";


export default function GroupPage(){
    const [show,setShow] = useState(false);
    const [groupName,setGroupName] = useState("");
    const [error,setError] = useState("");
    const [groupList,setGroupList] = useState([]);
    const user = JSON.parse(localStorage.getItem("user"));
    console.log(user)
    

    const handleAddGroups = async (e) => {
        e.preventDefault();
        setError("");
        try{
        const res =await axios.post("https://localhost:7179/group",{
            userId: user.userId,
            groupName: groupName
        });
        console.log(res);
    } catch(error){
        setError(error.response.data)
    }
    }
    const fetchGroup = async () => {
       try{
        const res = await axios.get("https://localhost:7179/group",{
            params: { userId: user.userId } 
        });
        console.log(res.data);
        setGroupList(res.data);
       }catch(error){
        console.log(error);
       }
        
    }

    useEffect(() => {fetchGroup();},[]);

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

        <section className="mt-5">
            <Container>
                <Row className="gap-3">
                    {groupList && groupList.map(group => 
                        <GroupComponent key={group.groupId} groupData={group}/>
                    )
                    }
                </Row>
            </Container>
        </section>
         
         
         
         
         
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
         <Form onSubmit={handleAddGroups}>
            <Form.Group className="mb-3">
              <Form.Label>Group Name</Form.Label>
              <Form.Control
                type="text"
                placeholder="e.g Trip"
                autoFocus
                value={groupName}
                onChange={(e) => setGroupName(e.target.value)}
              />
            </Form.Group>
            <div className="d-flex gap-2">
                 <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
                 <Button onClick={() => setShow(false)} className="flex-fill" type="submit">Create</Button>
            </div>
          </Form>
          {error === "" ? "" : <p className="text-danger">*{error}</p>}
      </Modal.Body>
    </Modal>
        </>
    )
}