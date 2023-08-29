// React component for start page with an example toast
import React from 'react';
import { Card, Button } from 'react-bootstrap';

// React component that renders a Card with a title, image,
// description and a button to show the page.
// 
// example:
//   <CardForPage title='Calculator' description='Simple calculator' image='calculator.svg' path='/calculator' />
//   <CardForPage page={{title: 'Calculator', description: 'Simple calculator', image: 'calculator.svg', path: '/calculator'}} />
//
// props:
//   title: String
//   description: String
//   image: String
//   path: String
//   page: Object with the following properties:
//      title: String
//      description: String
//      image: String
//      path: String
//
// Longer property paths override shorter paths, e.g., props.page.title 
// overrides props.title.

export default function CardForPage(props) {
  // get properties first from props.page, then from props, otherwise use default value
  const title = props.page?.title ?? props.title ?? '<title>';
  const image = props.page?.image ?? props.image ?? 'empty.svg';
  const description = props.page?.description ?? props.description ?? '<description>';
  const path = props.page?.path ?? props.path ?? '<path>';

  return (
    <Card className='shadow' style={{ width: '17rem', height: '20rem'}}>
      <Card.Header className='bg-light text-dark h5'>
        {title}
      </Card.Header>
      <Card.Img className='align-self-center mt-2' style={{ width: '100px', height: '100px'}} variant='top' src={image} />
      <Card.Body >
        <Card.Text>
          {description}
        </Card.Text>
        <Button href={path} variant='primary' className='position-absolute bottom-0 start-50 translate-middle'>Show me!</Button>
      </Card.Body>
    </Card>
  );
}

