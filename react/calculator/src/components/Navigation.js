import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

// React component that renders the component Navigation with 
// the brand and direct navigation links to the pages.
//
// example:
//   <Navigation logo={logo} title={title} links={links}/>
//
// props:
//    logo: String
//    title: String
//    links: Array of objects with the following properties:
//      title: String
//      path: String

export default function Navigation(props) {
  return (
    <Navbar expand="lg" className="bg-body-tertiary">
      <Container>
        
        <Navbar.Brand href="/">
          { props?.logo && <img alt="brand-logo" src={props.logo} width="32" height="32" className="d-inline-block align-top mx-2" />  }
          { props?.title || "" }
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            {
              props?.links?.map(({title, path}) => 
                <Nav.Link key={title} as="a" href={path}>{title}</Nav.Link>
              )
            }
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}
