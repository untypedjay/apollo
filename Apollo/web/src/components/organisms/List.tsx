import React from 'react';
import ListItem from '../molecules/ListItem';
import './List.css';

interface Props {
  title: string;
  data: any[];
  property: string;
  extraProperty: string;
  editAction: (item: any) => void;
  deleteAction: (item: any) => void;
}

function List({ title, data, property, extraProperty, editAction, deleteAction }: Props) {
  return (
    <div className="list">
      <h3 className="list__title">{ title }</h3>
      <div className="list__container">
        { data.map(item => {
          return (
            <ListItem
              key={item[property]}
              editAction={editAction}
              deleteAction={deleteAction}
              extraInfo={item[extraProperty]}
            >
              { item[property] }
            </ListItem>
          );
        })}
      </div>
    </div>
  );
}

export default List;