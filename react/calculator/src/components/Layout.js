import Container from 'react-bootstrap/Container';
import { Outlet } from 'react-router-dom';

// React component that renders the layout of the main part 
// of the page and centers children components.
//
// example:
//    <Layout />
//

export default function Layout() {
  return (
    <Container fluid className="p-5">
      <Container className="d-flex justify-content-center p-3 mb-4 bg-light rounded-3">
        <Outlet />
      </Container>
    </Container>
  );  
}