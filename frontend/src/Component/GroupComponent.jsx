import axios from "axios";
import { useEffect, useState } from "react"
import { Col,Button,Modal,Form } from "react-bootstrap"
export default function GroupComponent({groupData}){
    
    const [show,setShow] = useState(false)
   const user = JSON.parse(localStorage.getItem("user"));
    const [memberList,setMemberList] = useState([]);
    const [error,setError] = useState("");
    const [username,setUsername] = useState("");
    const fetchMember =  async () => {
      try {
        const res = await axios.get(`https://localhost:7179/group/${groupData.groupId}/members`);
        setMemberList(res.data);
        
      } catch (error) {
        console.log(error)
      }
    }
    const handleAddMember = async (e) => {
      e.preventDefault();
      setError("");
      try {
        const res = await axios.post(`https://localhost:7179/group/${groupData.groupId}/members`,{},{
          params : {username : username}
        });
        console.log(res)
        setShow(false);
        fetchMember();
       }catch (error) {
        setError(error.response.data)
       }
    }
    useEffect(() => {
        fetchMember();
      },[groupData])
    
    return (
        <>
            <Col md="4" key={groupData.groupId} className="bg-white rounded shadow py-3 px-3">
            <div className="d-flex justify-content-between align-items-center mx-0">
              <h5>{groupData.groupName}</h5>
              <span className="badge text-bg-secondary h-25">{memberList.length} members</span>
            </div>
                

               
                <ul className="mt-3 list-unstyled">
                    {memberList.map(member => (
                      <li key={member.userId}>{member.userId === user.userId ? member.username + " (you)" : member.username}</li>
                    ))}
                </ul>
                 <div className="d-flex justify-content-end">
                    <Button onClick={() => setShow(true)}>Add Member</Button>
                </div>
            </Col>


              <Modal
      show={show}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
      onHide={() => setShow(false)}
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Add Member
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
         <Form onSubmit={handleAddMember} >
            <Form.Group className="mb-3">
              <Form.Label>Enter user username to add</Form.Label>
              <Form.Control
                type="text"
                placeholder="e.g maxvu"
                autoFocus
                value={username}
                onChange={(e) => setUsername(e.target.value) }
              />
            </Form.Group>
               <p className="text-danger mt-3">{error !== "" ?  `*${error}` : ""}</p>

            <div className="d-flex gap-2">
                 <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
                 <Button className="flex-fill" type="submit">Add</Button>
            </div>
          </Form>
         
      </Modal.Body>
    </Modal>
        </>
    )
}