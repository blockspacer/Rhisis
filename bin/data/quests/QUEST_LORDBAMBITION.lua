QUEST_LORDBAMBITION = {
	title = 'IDS_PROPQUEST_INC_001185',
	character = 'MaFl_Luda',
	end_character = 'MaDa_Amadolka',
	start_requirements = {
		min_level = 60,
		max_level = 80,
		job = { 'JOB_VAGRANT', 'JOB_MERCENARY', 'JOB_ACROBAT', 'JOB_ASSIST', 'JOB_MAGICIAN', 'JOB_KNIGHT', 'JOB_BLADE', 'JOB_JESTER', 'JOB_RANGER', 'JOB_RINGMASTER', 'JOB_BILLPOSTER', 'JOB_PSYCHIKEEPER', 'JOB_ELEMENTOR', 'JOB_KNIGHT_MASTER', 'JOB_BLADE_MASTER', 'JOB_JESTER_MASTER', 'JOB_RANGER_MASTER', 'JOB_RINGMASTER_MASTER', 'JOB_BILLPOSTER_MASTER', 'JOB_PSYCHIKEEPER_MASTER', 'JOB_ELEMENTOR_MASTER', 'JOB_KNIGHT_HERO', 'JOB_BLADE_HERO', 'JOB_JESTER_HERO', 'JOB_RANGER_HERO', 'JOB_RINGMASTER_HERO', 'JOB_BILLPOSTER_HERO', 'JOB_PSYCHIKEEPER_HERO', 'JOB_ELEMENTOR_HERO' },
		previous_quest = 'QUEST_NEWLORDB',
	},
	rewards = {
		gold = 0,
		exp = 4529832,
	},
	end_conditions = {
		monsters = {
			{ id = 'MI_RBANG2', quantity = 35 },
		},
	},
	dialogs = {
		begin = {
			'IDS_PROPQUEST_INC_001186',
			'IDS_PROPQUEST_INC_001187',
			'IDS_PROPQUEST_INC_001188',
			'IDS_PROPQUEST_INC_001189',
		},
		begin_yes = {
			'IDS_PROPQUEST_INC_001190',
		},
		begin_no = {
			'IDS_PROPQUEST_INC_001191',
		},
		completed = {
			'IDS_PROPQUEST_INC_001192',
			'IDS_PROPQUEST_INC_001193',
		},
		not_finished = {
			'IDS_PROPQUEST_INC_001194',
		},
	}
}
