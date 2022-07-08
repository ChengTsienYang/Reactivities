import React from "react";
import { Button, Item, ItemContent, ItemHeader, Label, Segment } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";

interface Props{
    activities: Activity[];
}

export default function ActivityList({activities}:Props){
return(
    <Segment>
        <Item.Group divided>
{activities.map(activity => (
<Item key = {activity.id}>
    <ItemContent>
        <Item.Header as='a'>{activity.title}</Item.Header>
        <Item.Meta>{activity.date.toString()}</Item.Meta>
        <Item.Description>
            <div>{activity.description}</div>
            <div>{activity.city},{activity.venue}</div>
        </Item.Description>
    <Item.Extra>
        <Button floated='right' content='View' color='blue'/>
        <Label basic content={activity.category} />
    </Item.Extra>
    </ItemContent>
</Item>

))}
        </Item.Group>
    </Segment>
)
}