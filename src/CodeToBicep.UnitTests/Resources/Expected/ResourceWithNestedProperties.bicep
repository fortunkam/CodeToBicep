resource myresource 'my.resource.type@v123456' = {
	name: 'ResourceName'
	properties: {
		prop1: 'propVal1'
		prop2: 'propVal2'
		propDict: {
			subProp1: 'propVal1'
			subProp2: 'propVal2'
			subPropDict: {
				subSubProp1: 'propVal1'
				subSubProp2: 'propVal2'
			}
		}
	}
}